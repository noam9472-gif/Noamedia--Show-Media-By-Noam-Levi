using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteController : Controller
    {
        [HttpDelete("VideoDeleter/{id}")]
        public int DeleteVideo(int id)
        {
            try
            {
                VideoDB vdb = new();
                vdb.Delete(new Video { Id = id });
                return vdb.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Video Delete Error: " + ex.Message);
                return 0;
            }
        }
        [HttpDelete("UserDeleter/{id}")]
        public int DeleteUser(int id)
        {
            Console.WriteLine($"Server received ID: {id}");
            try
            {
                UserDB udb = new();
                User uDelete = new User { Id = id };
                udb.Delete(uDelete);
                return udb.SaveChanges(); // יחזיר 1 אם הצליח
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Error: " + ex.Message);
                return 0;
            }
        }
        [HttpDelete("DeleteGenre/{id}")]
        public int DeleteGenre(int id)
        {
            try
            {
                VideoDB vdb = new VideoDB();

                vdb.UpdateByCondition("Video", "Genre = 14", $"Genre = {id}");

                Console.WriteLine($"Moved movies from Genre {id} to 14.");

                // 2. מחיקת הז'אנר עצמו מטבלת Genre
                GenreDB gdb = new GenreDB();
                return gdb.DeleteByCondition("Genre", $"id = {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("SERVER ERROR: " + ex.Message);
                return 0;
            }
        }
        [HttpDelete("Review/{id}")] 
        public int DeleteReview(int id)
        {
            try
            {
                VideoReviewDB vrdb = new();
                vrdb.Delete(new VideoReview { Id = id });
                return vrdb.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Review Delete Error: " + ex.Message);
                return 0;
            }
        }
        [HttpDelete]
        [ActionName("UserPremiumDeleter")]
        public int DeleteUserPremium(UserPremium upDelete)
        {
            UserPremiumDB updb = new();
            updb.Delete(upDelete);
            int z = updb.SaveChanges();
            return z;
        }
        [HttpDelete("{id}")] 
        [ActionName("MyLikesDeleter")]
        public int DeleteMyLike(int id) 
        {
            MyLikesDB mldb = new MyLikesDB();

            MyLikes likeToDelete = new MyLikes { Id = id };

            mldb.Delete(likeToDelete); 
            int z = mldb.SaveChanges();
            return z;
        }
        [HttpDelete("{id}")]
        [ActionName("MyWatchListDeleter")]
        public int DeleteMyWatchList(int id)
        {
            MyWatchListDB mwldb = new MyWatchListDB();
            MyWatchList watchListToDelete = new MyWatchList { Id = id };
            mwldb.Delete(watchListToDelete);
            int z = mwldb.SaveChanges();
            return z;
        }
        [HttpDelete("{id}")]
        [ActionName("MyHistoryDeleter")]
        public int DeleteMyHistory(int id)
        {
            MyHistoryDB mhdb = new MyHistoryDB();
            MyHistory historyToDelete = new MyHistory { Id = id };
            mhdb.Delete(historyToDelete);
            int z = mhdb.SaveChanges();
            return z;
        }

        [HttpDelete("ForceClearUser/{id}")]
        public int ForceClearUserEverything(int id)
        {
            try
            {
                // 1. מחיקת ביקורות שהמשתמש כתב
                // שים לב: בדוק אם שם העמודה ב-Access הוא whoUpdatedTheReview
                new VideoReviewDB().DeleteByCondition("VideoReviews", $"whoUpdatedTheReview = {id}");

                // 2. מחיקת לייקים של המשתמש
                new MyLikesDB().DeleteByCondition("MyLikes", $"whoLiked = {id}");

                // 3. מחיקת פרימיום אם קיים
                new UserPremiumDB().DeleteByCondition("UserPremium", $"userId = {id}");

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ForceClearUser Error: " + ex.Message);
                return 0;
            }
        }

        [HttpDelete("ForceClearVideo/{id}")]
        public int ForceClearVideo(int id)
        {
            try
            {
                // 1. מחיקת כל הביקורות על הסרט הספציפי
                // שים לב: בדוק אם שם העמודה ב-Access הוא whichVideoDidTheUserReview
                new VideoReviewDB().DeleteByCondition("VideoReviews", $"whichVideoDidTheUserReview = {id}");

                // 2. מחיקת לייקים על הסרט
                new MyLikesDB().DeleteByCondition("MyLikes", $"whichVideoIsLiked = {id}");

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ForceClearVideo Error: " + ex.Message);
                return 0;
            }
        }
    }
}
