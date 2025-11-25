using Model;
using Noamedia__Show_Media_By_Noam_Levi;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = $"SELECT * FROM [User]";
            UserList groupList = new UserList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User u = entity as User;
            u.Name = reader["UserName"].ToString();
            u.Pass = reader["Pass"].ToString();
            u.Mail = reader["Mail"].ToString();
            u.UserName = reader["Name"].ToString();
            u.DateOfBirth = (DateTime)reader["DateOfBirth"];
            base.CreateModel(entity);
            return u;
        }
        public override BaseEntity NewEntity()
        {
            return new User();
        }
        static private UserList list = new UserList();

        public static User SelectById(int id)
        {
            UserDB db = new UserDB();
            list = db.SelectAll();

            User g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"DELETE FROM [User] WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", u.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"Insert INTO [User] (UserName, DateOfBirth, Mail, Pass, Name) VALUES (@UserName, @DateOfBirth, @Mail, @Pass, @Name)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@UserName", u.UserName));
                command.Parameters.Add(new OleDbParameter("@DateOfBirth", u.DateOfBirth));
                command.Parameters.Add(new OleDbParameter("@Mail", u.Mail));
                command.Parameters.Add(new OleDbParameter("@Pass", u.Pass));
                command.Parameters.Add(new OleDbParameter("@Name", u.Name));

            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"UPDATE [User] SET UserName=@UserName," +
                    $" DateOfBirth=@DateOfBirth, Mail=@Mail, Pass=@Pass, Name=@Name" +
                    $" WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@UserName", u.UserName));
                command.Parameters.Add(new OleDbParameter("@DateOfBirth", u.DateOfBirth));
                command.Parameters.Add(new OleDbParameter("@Mail", u.Mail));
                command.Parameters.Add(new OleDbParameter("@Pass", u.Pass));
                command.Parameters.Add(new OleDbParameter("@Name", u.UserName));
                command.Parameters.Add(new OleDbParameter("@ID", u.Id));
            }
        }

        //שלב ב
        //protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    City c = entity as City;
        //    if (c != null)
        //    {
        //        string sqlStr = $"DELETE FROM CityTbl where id=@pid";

        //        command.CommandText = sqlStr;
        //        command.Parameters.Add(new OleDbParameter("@pid", c.Id));
        //    }
        //}
        //protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    City c = entity as City;
        //    if (c != null)
        //    {
        //        string sqlStr = $"Insert INTO  CityTbl (CityName) VALUES (@cName)";

        //        command.CommandText = sqlStr;
        //        command.Parameters.Add(new OleDbParameter("@cName", c.CityName));
        //    }
        //}

        //protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    City c = entity as City;
        //    if (c != null)
        //    {
        //        string sqlStr = $"UPDATE CityTbl  SET CityName=@cName WHERE ID=@id";

        //        command.CommandText = sqlStr;
        //        command.Parameters.Add(new OleDbParameter("@cName", c.CityName));
        //        command.Parameters.Add(new OleDbParameter("@id", c.Id));
        //    }
        //}
    }
}