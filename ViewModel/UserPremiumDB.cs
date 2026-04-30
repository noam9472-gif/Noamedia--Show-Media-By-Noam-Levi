using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserPremiumDB : UserDB
    {
        public UserPremiumList SelectAll()
        {
            command.CommandText = "SELECT UserPremium.ID, UserPremium.IdentityCard, " +
    "[User].UserName, [User].DateOfBirth, [User].Mail, [User].Pass, " +
    "[User].Name, [User].IsAdmin, [User].IsPremium " + 
    "FROM (UserPremium INNER JOIN [User] ON UserPremium.ID = [User].ID)";
            UserPremiumList groupList = new UserPremiumList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserPremium ct = entity as UserPremium;
            ct.IdentityCard = reader["IdentityCard"].ToString();
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new UserPremium();
        }
        static private UserPremiumList list = new UserPremiumList();

        public static UserPremium SelectById(int id)
        {
            UserPremiumDB db = new UserPremiumDB();
            list = db.SelectAll();

            UserPremium g = list.Find(item => item.Id == id);
            return g;
        }
        public override void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
           UserPremium ur = entity as UserPremium;
              if (ur != null)
              {
                string sqlStr = $"DELETE FROM UserPremium where ID=@ID";
    
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", ur.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            UserPremium ur = entity as UserPremium;
            if (ur != null)
            {
                string sqlStr = $"Insert INTO  UserPremium (ID, IdentityCard) VALUES (@ID, @IdentityCard)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", ur.Id));
                command.Parameters.Add(new OleDbParameter("@IdentityCard", ur.IdentityCard));

            }
        }

        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            UserPremium ur = entity as UserPremium;
            if (ur != null)
            {
                string sqlStr = $"UPDATE UserPremium SET IdentityCard=@IdentityCard WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@IdentityCard", ur.IdentityCard));
                command.Parameters.Add(new OleDbParameter("@ID", ur.Id));
            }
        }
    }
}