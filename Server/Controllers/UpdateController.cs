using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;


namespace Movies.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UpdateController : Controller
    {
        [HttpPut]
        [ActionName("VideoUpdater")]
        public int UpdateVideo([FromBody] Video video)
        {
            VideoDB vdb = new VideoDB();
            vdb.Update(video);
            int x = vdb.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("GenreUpdater")]
        public int UpdateGenre([FromBody] Genre genre)
        {
            GenreDB gdb = new GenreDB();
            gdb.Update(genre);
            int x = gdb.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UserUpdater")]
        public int UpdateUser([FromBody] User user)
        {
            UserDB udb = new UserDB();
            udb.Update(user);
            int x = udb.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("UserPremiumUpdater")]
        public int UpdateUserPremium([FromBody] UserPremium userPremium)
        {
            UserPremiumDB updb = new UserPremiumDB();
            updb.Update(userPremium);
            int x = updb.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("VideoReviewUpdater")]
        public int UpdateVideoReview([FromBody] VideoReview videoReview)
        {
            VideoReviewDB vrdb = new VideoReviewDB();
            vrdb.Update(videoReview);
            int x = vrdb.SaveChanges();
            return x;
        }
        [HttpPut("UpdateMovieGenre/{videoId}/{newGenreId}")]
        public int UpdateMovieGenre(int videoId, int newGenreId)
        {
            try
            {
                VideoDB vdb = new VideoDB();
                return vdb.UpdateByCondition("Video", $"Genre = {newGenreId}", $"id = {videoId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server Error: " + ex.Message);
                return 0;
            }
        }

        
        [HttpPut("{userId}")]
        [ActionName("UpdateToPremium")]
        public int UpdateToPremium(int userId)
        {
            try
            {
                // 1. עדכון שדה IsPremium בטבלת המשתמשים (כדי שהמנהל יראה 1)
                UserDB udb = new UserDB();
                udb.UpdateByCondition("User", "IsPremium = 1", $"id = {userId}");

                // 2. טיפול בטבלת UserPremium עבור דף הכניסה
                UserPremiumDB updb = new UserPremiumDB();

                // שימוש בפונקציה החדשה שכתבנו כדי לבדוק אם הוא כבר פרימיום
                UserPremiumList existing = updb.SelectByCondition($"id = {userId}");

                if (existing == null || existing.Count == 0)
                {
                    // אם הוא לא קיים בטבלה, נוסיף אותו
                    UserPremium up = new UserPremium { Id = userId };
                    updb.Insert(up);
                    return updb.SaveChanges();
                }

                return 1; // המשתמש כבר קיים בטבלה, אז מחזירים הצלחה
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server Error: " + ex.Message);
                return 0;
            }
        }
    }
}