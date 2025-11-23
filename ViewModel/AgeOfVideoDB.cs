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
    public class AgeOfVideosDB : BaseDB
    {


        public AgeOfVideoList SelectAll()
        {
            command.CommandText = $"SELECT * FROM AgeOfVideos";
            AgeOfVideoList groupList = new AgeOfVideoList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            AgeOfVideos ct = entity as AgeOfVideos;
          
            ct.Description = reader["description"].ToString();
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new AgeOfVideos();
        }
        static private AgeOfVideoList list = new AgeOfVideoList();

        public static AgeOfVideos SelectById(int id)
        {
            AgeOfVideosDB db = new AgeOfVideosDB();
            list = db.SelectAll();

            AgeOfVideos g = list.Find(item => item.Id == id);
            return g;
        }
        public override void Delete(BaseEntity entity)
        {
            base.Delete(entity);
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeOfVideos aov = entity as AgeOfVideos;
            if (aov != null)
            {
                string sqlStr = $"DELETE FROM AgeOfVideos where ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeOfVideos aov = entity as AgeOfVideos;
            if (aov != null)
            {
                string sqlStr = $"Insert INTO AgeOfVideos ( description ) VALUES ( @description)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@description", aov.Description));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AgeOfVideos aov = entity as AgeOfVideos;
            if (aov != null)
            {
                string sqlStr = $"UPDATE AgeOfVideos SET Description=@description WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@description", aov.Description));
                command.Parameters.Add(new OleDbParameter("@ID", aov.Id));
            }
        }

        //        שלב ב
        //        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        //        {
        //            City c = entity as City;
        //            if (c != null)
        //            {
        //                string sqlStr = $"DELETE FROM CityTbl where id=@pid";

        //                command.CommandText = sqlStr;
        //                command.Parameters.Add(new OleDbParameter("@pid", c.Id));
        //            }
        //        }
        //        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        //        {
        //            City c = entity as City;
        //            if (c != null)
        //            {
        //                string sqlStr = $"Insert INTO  CityTbl (CityName) VALUES (@cName)";

        //                command.CommandText = sqlStr;
        //                command.Parameters.Add(new OleDbParameter("@cName", c.CityName));
        //            }
        //        }

        //        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        //        {
        //            City c = entity as City;
        //            if (c != null)
        //            {
        //                string sqlStr = $"UPDATE CityTbl  SET CityName=@cName WHERE ID=@id";

        //                command.CommandText = sqlStr;
        //                command.Parameters.Add(new OleDbParameter("@cName", c.CityName));
        //                command.Parameters.Add(new OleDbParameter("@id", c.Id));
        //            }
        //        }

    }
}