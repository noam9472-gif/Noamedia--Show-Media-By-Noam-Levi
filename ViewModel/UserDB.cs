using Model;
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
            u.IsAdmin = (bool)reader["IsAdmin"];
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
                cmd.CommandText = "INSERT INTO [User] ([UserName], [DateOfBirth], [Mail], [Pass], [Name], [IsAdmin]) " +
                                 "VALUES (?, ?, ?, ?, ?, ?)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@UserName", OleDbType.VarWChar).Value = u.UserName;
                cmd.Parameters.Add("@DateOfBirth", OleDbType.Date).Value = u.DateOfBirth;
                cmd.Parameters.Add("@Mail", OleDbType.VarWChar).Value = u.Mail;
                cmd.Parameters.Add("@Pass", OleDbType.VarWChar).Value = u.Pass;
                cmd.Parameters.Add("@Name", OleDbType.VarWChar).Value = u.Name;

                // כאן הקאץ'! וודא שזה Boolean עבור שדה Yes/No ב-Access
                cmd.Parameters.Add("@IsAdmin", OleDbType.Boolean).Value = u.IsAdmin;
            }
        }
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"UPDATE [User] SET UserName=@UserName," +
                $" DateOfBirth=@DateOfBirth, Mail=@Mail, Pass=@Pass, Name=@Name" + // חסר פסיק כאן!
                $" IsAdmin=@IsAdmin WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@UserName", u.UserName));
                command.Parameters.Add(new OleDbParameter("@DateOfBirth", u.DateOfBirth));
                command.Parameters.Add(new OleDbParameter("@Mail", u.Mail));
                command.Parameters.Add(new OleDbParameter("@Pass", u.Pass));
                command.Parameters.Add(new OleDbParameter("@Name", u.UserName));
                command.Parameters.Add(new OleDbParameter("@IsAdmin", u.IsAdmin));
                command.Parameters.Add(new OleDbParameter("@ID", u.Id));
            }
        }
    }
}