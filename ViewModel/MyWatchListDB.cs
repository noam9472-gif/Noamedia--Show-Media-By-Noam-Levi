using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class MyWatchListDB : BaseDB
    {
        public MyWatchListList SelectAll()
        {
            command.CommandText = "SELECT * FROM MyWatchList"; 
            MyWatchListList groupList = new MyWatchListList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyWatchList ct = entity as MyWatchList;
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
            return new MyWatchList();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyWatchList aov = entity as MyWatchList;
            if (aov != null && aov.UserId != null && aov.VideoId != null)
            {
                cmd.CommandText = "INSERT INTO MyWatchList (UserId, VideoId) VALUES (@UserId, @VideoId)";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyWatchList aov = entity as MyWatchList;
            if (aov != null)
            {
                cmd.CommandText = "UPDATE MyWatchList SET UserId=@UserId, VideoId=@VideoId WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyWatchList aov = entity as MyWatchList;
            if (aov != null)
            {
                cmd.CommandText = "DELETE FROM MyWatchList WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        static private MyWatchListList list = new MyWatchListList();
        public static MyWatchList SelectById(int id)
        {
            MyWatchListDB db = new MyWatchListDB();
            list = db.SelectAll();
            return list.Find(item => item.Id == id);
        }
    }
}