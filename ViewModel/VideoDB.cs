using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VideoDB : BaseDB
    {
        public VideoList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Video";
            VideoList groupList = new VideoList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Video ct = entity as Video;
            ct.LengthInMinutes = int.Parse(reader["LengthInMinutes"].ToString());
            ct.AgeOfVideo = AgeOfVideosDB.SelectById((int)reader["AgeOfVideo"]);
            ct.WhoUploadedTheVideo = UserDB.SelectById((int)reader["WhoUploadedTheVideo"]);
            ct.VideoName = reader["VideoName"].ToString();
            ct.Genre = GenreDB.SelectById((int)reader["Genre"]);
            ct.VideoAddress = reader["VideoAddress"].ToString();
            ct.VideoUploadedDate = (DateTime)reader["VideoUploadedDate"];
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new Video();
        }
        static private VideoList list = new VideoList();

        public static Video SelectById(int id)
        {
            VideoDB db = new VideoDB();
            list = db.SelectAll();

            Video g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                string sqlStr = $"DELETE FROM Video where ID=@ID";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", v.Id));

            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                string sqlStr = $"Insert INTO Video ( VideoUploadedDate , LengthInMinutes , WhoUploadedTheVideo , VideoName , Genre , AgeOfVideo , VideoAddress) VALUES ( @VideoUploadedDate , @LengthInMinutes , @WhoUploadedTheVideo , @VideoName , @Genre , @AgeOfVideo , @VideoAddress)";

                command.CommandText = sqlStr;
                 command.Parameters.Add(new OleDbParameter("@VideoUploadedDate", v.VideoUploadedDate));
                command.Parameters.Add(new OleDbParameter("@LengthInMinutes", v.LengthInMinutes));
                command.Parameters.Add(new OleDbParameter("@WhoUploadedTheVideo", v.WhoUploadedTheVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoName", v.VideoName));
                command.Parameters.Add(new OleDbParameter("@Genre", v.Genre.Id));
                command.Parameters.Add(new OleDbParameter("@AgeOfVideo", v.AgeOfVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoAddress", v.VideoAddress));

            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                string sqlStr = $"UPDATE Video SET " +
                    $"VideoUploadedDate=@VideoUploadedDate, LengthInMinutes=@LengthInMinutes," +
                    $" WhoUploadedTheVideo=@WhoUploadedTheVideo, VideoName=@VideoName," +
                    $" Genre=@Genre, AgeOfVideo=@AgeOfVideo, VideoAddress=@VideoAddress" +
                    $" WHERE ID=@ID";

                command.CommandText = sqlStr;
                OleDbParameter dataParam = new OleDbParameter("@VideoUploadedDate", OleDbType.DBDate);
                dataParam.Value = v.VideoUploadedDate.Date;
                command.Parameters.Add(dataParam);
                command.Parameters.Add(new OleDbParameter("@LengthInMinutes", v.LengthInMinutes));
                command.Parameters.Add(new OleDbParameter("@WhoUploadedTheVideo", v.WhoUploadedTheVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoName", v.VideoName));
                command.Parameters.Add(new OleDbParameter("@Genre", v.Genre.Id));
                command.Parameters.Add(new OleDbParameter("@AgeOfVideo", v.AgeOfVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoAddress", v.VideoAddress));
                command.Parameters.Add(new OleDbParameter("@ID", v.Id));


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