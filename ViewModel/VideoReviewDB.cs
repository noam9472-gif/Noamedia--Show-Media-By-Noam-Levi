using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VideoReviewDB : BaseDB
    {
        public VideoReviewList SelectAll()
        {
            command.CommandText = $"SELECT * FROM VideoReview";
            VideoReviewList groupList = new VideoReviewList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            VideoReview ct = entity as VideoReview;
            ct.WhoUpdatedTheReview = UserDB.SelectById((int)reader["WhoUpdatedTheReview"]);
            ct.WhichVideoDidTheUserReview = VideoDB.SelectById((int)reader["WhichVideoDidTheUserReview"]);
            ct.ReviewDescription = reader["ReviewDescription"].ToString();
            ct.ReviewDate = (DateTime)reader["ReviewDate"];
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new VideoReview();
        }
        static private VideoReviewList list = new VideoReviewList();

        public static VideoReview SelectById(int id)
        {
            VideoReviewDB db = new VideoReviewDB();
            list = db.SelectAll();

            VideoReview g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            VideoReview vr = entity as VideoReview;
            if (vr != null)
            {
                string sqlStr = $"DELETE FROM VideoReview where ID=@ID";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", vr.Id));
               
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            VideoReview vr = entity as VideoReview;
            if (vr != null)
            {
                cmd.CommandText = "INSERT INTO VideoReview (WhoUpdatedTheReview, WhichVideoDidTheUserReview, ReviewDate, ReviewDescription) VALUES (?, ?, ?, ?)";
                cmd.Parameters.Clear();


                cmd.Parameters.Add(new OleDbParameter("@Who", vr.WhoUpdatedTheReview.Id));
                cmd.Parameters.Add(new OleDbParameter("@Which", vr.WhichVideoDidTheUserReview.Id));
                cmd.Parameters.Add("@Date", OleDbType.Date).Value = vr.ReviewDate;
                cmd.Parameters.Add(new OleDbParameter("@Desc", vr.ReviewDescription ?? ""));
            }
        }
     
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            VideoReview vr = entity as VideoReview;
            if (vr != null)
            {
                string sqlStr = $"UPDATE VideoReview SET ReviewDescription=@ReviewDescription , ReviewDate=@ReviewDate, WhichVideoDidTheUserReview=@WhichVideoDidTheUserReview , WhoUpdatedTheReview=@WhoUpdatedTheReview WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Clear(); 

                command.Parameters.Add(new OleDbParameter("@ReviewDescription", vr.ReviewDescription));
                command.Parameters.Add(new OleDbParameter("@ReviewDate", vr.ReviewDate));
                command.Parameters.Add(new OleDbParameter("@WhichVideoDidTheUserReview", vr.WhichVideoDidTheUserReview));
                command.Parameters.Add(new OleDbParameter("@WhoUpdatedTheReview", vr.WhoUpdatedTheReview.Id));
                command.Parameters.Add(new OleDbParameter("@ID", vr.Id));
            }
        }
    }
}