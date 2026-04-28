using Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

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
        protected static OleDbTransaction currentTransaction; // הוספנו משתנה שיזכור את הטרנזקציה

        public BaseDB()
        {
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
                if (connection.State != ConnectionState.Open) connection.Open();

                command.Connection = connection;
                // תיקון: אם יש טרנזקציה פתוחה, חייבים לשייך אותה לפקודה
                command.Transaction = currentTransaction;

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
                if (reader != null) { reader.Close(); reader.Dispose(); }
            }
            return list;
        }

        protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        {
            List<BaseEntity> list = new List<BaseEntity>();
            // ב-Async מומלץ ליצור חיבור חדש כדי למנוע התנגשויות
            using (OleDbConnection localConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand localCmd = new OleDbCommand(sqlStr, localConn))
                {
                    try
                    {
                        await localConn.OpenAsync();
                        using (var localReader = (OleDbDataReader)await localCmd.ExecuteReaderAsync())
                        {
                            while (await localReader.ReadAsync())
                            {
                                this.reader = localReader; // לצורך CreateModel
                                BaseEntity entity = NewEntity();
                                list.Add(CreateModel(entity));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + sqlStr);
                    }
                }
            }
            return list;
        }

        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["id"];
            return entity;
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
        }
        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> deleted = new List<ChangeEntity>();

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
        }
        protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> inserted = new List<ChangeEntity>();

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
        }
        protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);
        public List<ChangeEntity> updated = new List<ChangeEntity>();

        public int SaveChanges()
        {
            int records_affected = 0;
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();

                // אתחול הטרנזקציה ושמירתה במשתנה הסטטי כדי ששאר הפונקציות יכירו אותה
                currentTransaction = connection.BeginTransaction();

                command.Connection = connection;
                command.Transaction = currentTransaction;

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

                currentTransaction.Commit();
            }
            catch (Exception ex)
            {
                // בדיקה שהטרנזקציה קיימת לפני שמבטלים אותה
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                throw new Exception(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
                // איפוס חובה כדי שלא יישאר זכר לטרנזקציה בפעולה הבאה
                currentTransaction = null;
                inserted.Clear();
                updated.Clear();
                deleted.Clear();
            }
            return records_affected;
        }

        public int DeleteByCondition(string tableName, string condition)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                OleDbCommand directCommand = new OleDbCommand($"DELETE FROM [{tableName}] WHERE {condition}", connection);
                directCommand.Transaction = currentTransaction;
                return directCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public int UpdateByCondition(string tableName, string setClause, string condition)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                OleDbCommand directCommand = new OleDbCommand($"UPDATE [{tableName}] SET {setClause} WHERE {condition}", connection);
                directCommand.Transaction = currentTransaction;
                return directCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static string GetDatabasePath() { /* הקוד שלך ללא שינוי */ return ""; }
    }
}