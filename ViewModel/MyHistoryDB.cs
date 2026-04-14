using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class MyHistoryDB : BaseDB
    {
        public MyHistoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM MyHistory";
            MyHistoryList groupList = new MyHistoryList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyHistory ct = entity as MyHistory;
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
            return new MyHistory();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyHistory aov = entity as MyHistory;
            if (aov != null && aov.UserId != null && aov.VideoId != null)
            {
                cmd.CommandText = "INSERT INTO MyHistory (UserId, VideoId) VALUES (@UserId, @VideoId)";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyHistory aov = entity as MyHistory;
            if (aov != null)
            {
                cmd.CommandText = "UPDATE MyHistory SET UserId=@UserId, VideoId=@VideoId WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@UserId", aov.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@VideoId", aov.VideoId.Id));
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MyHistory aov = entity as MyHistory;
            if (aov != null)
            {
                cmd.CommandText = "DELETE FROM MyHistory WHERE ID=@ID";
                cmd.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        static private MyHistoryList list = new MyHistoryList();
        public static MyHistory SelectById(int id)
        {
            MyHistoryDB db = new MyHistoryDB();
            list = db.SelectAll();
            return list.Find(item => item.Id == id);
        }
    }
}