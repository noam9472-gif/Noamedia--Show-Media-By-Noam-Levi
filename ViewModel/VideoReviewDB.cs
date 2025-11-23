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

        //public override void Delete(BaseEntity entity)
        //{
        //    BaseEntity reqEntity = this.NewEntity();
        //    if (entity != null & entity.GetType() == reqEntity.GetType())
        //    {
        //        deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
        //        deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
        //    }
        //}
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
                string sqlStr = $"Insert INTO VideoReview ( WhoUpdatedTheReview , WhichVideoDidTheUserReview , ReviewDate , ReviewDescription) VALUES ( @WhoUpdatedTheReview , @WhichVideoDidTheUserReview , @ReviewDate , @ReviewDescription)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@WhoUpdatedTheReview", vr.WhoUpdatedTheReview));
                command.Parameters.Add(new OleDbParameter("@WhichVideoDidTheUserReview", vr.WhichVideoDidTheUserReview));
                command.Parameters.Add(new OleDbParameter("@ReviewDate", vr.ReviewDate));
                command.Parameters.Add(new OleDbParameter("@ReviewDescription", vr.ReviewDescription));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            VideoReview vr = entity as VideoReview;
            if (vr != null)
            {
                string sqlStr = $"UPDATE VideoReview SET ReviewDescription=@ReviewDescription , ReviewDate=@ReviewDate, WhichVideoDidTheUserReview=@WhichVideoDidTheUserReview , WhoUpdatedTheReview=@WhoUpdatedTheReview WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ReviewDescription", vr.ReviewDescription));
                command.Parameters.Add(new OleDbParameter("@ReviewDate", vr.ReviewDate));
                command.Parameters.Add(new OleDbParameter("@WhichVideoDidTheUserReview", vr.WhichVideoDidTheUserReview));
                command.Parameters.Add(new OleDbParameter("@WhoUpdatedTheReview", vr.WhoUpdatedTheReview.Id));
                command.Parameters.Add(new OleDbParameter("@ID", vr.Id));
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