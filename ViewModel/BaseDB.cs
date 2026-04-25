using Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using static ViewModel.BaseDB;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                      + System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
                      + "/../../../../../ViewModel/NoamFlix- project netflix Noam Levi 12-71.accdb");

        protected static OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public BaseDB()
        {
            var x = GetDatabasePath();
            connection ??= new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public abstract BaseEntity NewEntity();

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return list;
        }

        protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                command.Connection = connection;
                command.CommandText = sqlStr;
                connection.Open();
                this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return list;
        }

        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["id"];
            return entity;
        }

        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> deleted = new List<ChangeEntity>();

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }

        protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> inserted = new List<ChangeEntity>();

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> updated  = new List<ChangeEntity>();

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }

        public int SaveChanges()
        {
            OleDbTransaction trans = null;
            int records_affected = 0;

            try
            {
                command.Connection = connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                foreach (var entity in updated)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);
                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);
                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw new Exception(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();
            }

            return records_affected;
        }

        public static string GetDatabasePath()
        {
            String[] args = Environment.GetCommandLineArgs();
            string s;
            if (args.Length == 1) { s = args[0]; }
            else
            {
                s = args[1];
                s = s.Replace("/service:", "");
            }
            string[] st = s.Split('\\');
            int x = st.Length - 6;
            st[x] = "ViewModel";
            Array.Resize(ref st, x + 1);
            string str = String.Join('\\', st);
            return str;
        }

        public int DeleteByCondition(string tableName, string condition)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                OleDbCommand directCommand = new OleDbCommand($"DELETE FROM [{tableName}] WHERE {condition}", connection);
                return directCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Direct Delete Error in {tableName}: {ex.Message}");
            }
        }

        // --- הפונקציה החדשה לטיפול בז'אנרים ---
        public int UpdateByCondition(string tableName, string setClause, string condition)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                // SQL לדוגמה: UPDATE Videos SET genreId = 1 WHERE genreId = 5
                OleDbCommand directCommand = new OleDbCommand($"UPDATE [{tableName}] SET {setClause} WHERE {condition}", connection);
                return directCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Direct Update Error in {tableName}: {ex.Message}");
            }
        }
    }
}