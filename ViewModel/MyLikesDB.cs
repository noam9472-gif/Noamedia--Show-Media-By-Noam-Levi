using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class MyLikesDB : BaseDB
    {
        public MyLikesList SelectAll()
        {
            command.CommandText = "SELECT * FROM MyLikes"; 
            MyLikesList groupList = new MyLikesList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyLikes ct = entity as MyLikes;
            if (ct != null)
            {
                ct.Id = (int)reader["ID"];

                int uId = (int)reader["UserId"];
                int vId = (int)reader["VideoId"];

                ct.UserId = UserDB.SelectById(uId);
                ct.VideoId = VideoDB.SelectById(vId);
            }
            return ct;
        }

        public override BaseEntity NewEntity()
        {
            return new MyLikes();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyLikes aov = entity as MyLikes;
            if (aov != null && aov.UserId != null && aov.VideoId != null)
            {
                cmd.CommandText = "INSERT INTO MyLikes (UserId, VideoId) VALUES (@UserId, @VideoId)";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyLikes aov = entity as MyLikes;
            if (aov != null)
            {
                cmd.CommandText = "UPDATE MyLikes SET UserId=@UserId, VideoId=@VideoId WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyLikes aov = entity as MyLikes;
            if (aov != null)
            {
                cmd.CommandText = "DELETE FROM MyLikes WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        static private MyLikesList list = new MyLikesList();
        public static MyLikes SelectById(int id)
        {
            MyLikesDB db = new MyLikesDB();
            list = db.SelectAll();
            return list.Find(item => item.Id == id);
        }
    }
}