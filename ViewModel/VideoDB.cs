using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            if (ct != null)
            {
                // קריאת נתונים בסיסיים
                ct.Id = int.Parse(reader["ID"].ToString());
                ct.LengthInMinutes = int.Parse(reader["LengthInMinutes"].ToString());
                ct.AgeOfVideo = AgeOfVideosDB.SelectById((int)reader["AgeOfVideo"]);
                ct.WhoUploadedTheVideo = UserDB.SelectById((int)reader["WhoUploadedTheVideo"]);
                ct.VideoName = reader["VideoName"].ToString();
                ct.Genre = GenreDB.SelectById((int)reader["Genre"]);
                ct.VideoAddress = reader["VideoAddress"].ToString();
                ct.VideoUploadedDate = (DateTime)reader["VideoUploadedDate"];

                // תיקון 1: קריאת התיאור (שלא יהיה null)
                ct.VideoDescription = reader["VideoDescription"] != DBNull.Value ? reader["VideoDescription"].ToString() : "";

                // תיקון 2: הפיכת שם הקובץ לקוד ארוך (Base64)
                string fileName = reader["VideoPic"] != DBNull.Value ? reader["VideoPic"].ToString() : "";

                if (!string.IsNullOrEmpty(fileName))
                {
                    // הנתיב לתיקייה בתוך השרת
                    string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyPictures");
                    string fullPath = System.IO.Path.Combine(folderPath, fileName);

                    // הדפסה לחלון ה-Output כדי שתוכל לראות איפה הוא מחפש
                    System.Diagnostics.Debug.WriteLine("Full Path Check: " + fullPath);

                    // המרת הקובץ מהתיקייה למחרוזת ארוכה
                    ct.VideoPic = ImageToBase64Converter.ImageToBase64(fullPath);
                }
                else
                {
                    ct.VideoPic = "";
                }
            }
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

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                string sqlStr = $"Insert INTO Video ( VideoUploadedDate , LengthInMinutes , WhoUploadedTheVideo , VideoName , Genre , AgeOfVideo , VideoAddress, VideoDescription, VideoPic) VALUES ( @VideoUploadedDate , @LengthInMinutes , @WhoUploadedTheVideo , @VideoName , @Genre , @AgeOfVideo , @VideoAddress, @VideoDescription, @VideoPic)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@VideoUploadedDate", v.VideoUploadedDate));
                command.Parameters.Add(new OleDbParameter("@LengthInMinutes", v.LengthInMinutes));
                command.Parameters.Add(new OleDbParameter("@WhoUploadedTheVideo", v.WhoUploadedTheVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoName", v.VideoName));
                command.Parameters.Add(new OleDbParameter("@Genre", v.Genre.Id));
                command.Parameters.Add(new OleDbParameter("@AgeOfVideo", v.AgeOfVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoAddress", v.VideoAddress));
                command.Parameters.Add(new OleDbParameter("@VideoDescription", v.VideoDescription));

                // כאן אנחנו שומרים את שם הקובץ (למשל "1.jpg")
                command.Parameters.Add(new OleDbParameter("@VideoPic", v.VideoPic ?? ""));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                string sqlStr = $"UPDATE Video SET VideoUploadedDate=@VideoUploadedDate, LengthInMinutes=@LengthInMinutes, WhoUploadedTheVideo=@WhoUploadedTheVideo, VideoName=@VideoName, Genre=@Genre, AgeOfVideo=@AgeOfVideo, VideoAddress=@VideoAddress, VideoDescription=@VideoDescription, VideoPic=@VideoPic WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@VideoUploadedDate", v.VideoUploadedDate));
                command.Parameters.Add(new OleDbParameter("@LengthInMinutes", v.LengthInMinutes));
                command.Parameters.Add(new OleDbParameter("@WhoUploadedTheVideo", v.WhoUploadedTheVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoName", v.VideoName));
                command.Parameters.Add(new OleDbParameter("@Genre", v.Genre.Id));
                command.Parameters.Add(new OleDbParameter("@AgeOfVideo", v.AgeOfVideo.Id));
                command.Parameters.Add(new OleDbParameter("@VideoAddress", v.VideoAddress));
                command.Parameters.Add(new OleDbParameter("@VideoDescription", v.VideoDescription));
                command.Parameters.Add(new OleDbParameter("@VideoPic", v.VideoPic ?? ""));
                command.Parameters.Add(new OleDbParameter("@ID", v.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Video v = entity as Video;
            if (v != null)
            {
                command.CommandText = $"DELETE FROM Video where ID=@ID";
                command.Parameters.Add(new OleDbParameter("@ID", v.Id));
            }
        }
        public string SelectVideoPicById(int id)
        {
            VideoList vList = SelectAll();
            Video vP = vList.Find(x => x.Id == id);

            if (vP != null)
            {
                return vP.VideoPic; 
            }
            return ""; // אם לא נמצא סרט
        }
    }
}