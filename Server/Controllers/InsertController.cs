using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsertController : Controller
    {

        // GET: InsertController
        [HttpPost]
        [Route("api/Insert/VideoInserter")]
        public int AddVideo(Video v)
        {
            try
            {
                VideoDB vdb = new();
                vdb.Insert(v);
                return vdb.SaveChanges();
            }
            catch (Exception ex)
            {
                // זה ידפיס לך בדיוק למה הסרט לא נשמר
                Console.WriteLine("INSERT ERROR: " + ex.Message);
                if (ex.InnerException != null) Console.WriteLine("INNER: " + ex.InnerException.Message);
                return 0;
            }
        }
        [HttpPost]
        [ActionName("UserInserter")]
        public int InsertUser([FromBody] User user)
        {
            UserDB udb = new UserDB();
            udb.Insert(user);
            int x = udb.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InserterGenre")]
        public int InsertGenre([FromBody] Genre genre)
        {
            GenreDB gdb = new GenreDB();
            gdb.Insert(genre);
            int x = gdb.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("VideoReviewInserter")]
        public int InsertVideoReview([FromBody] VideoReview videoReview)
        {
            VideoReviewDB vrdb = new VideoReviewDB();
            vrdb.Insert(videoReview);
            int x = vrdb.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("UserPremiumInserter")]
        public int InsertUserPremium([FromBody] UserPremium userPremium)
        {
            UserPremiumDB updb = new UserPremiumDB();
            updb.Insert(userPremium);
            int x = updb.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("AgeOfVideoInserter")]
        public int InsertAgeOfVideo([FromBody] AgeOfVideos ageOfVideo)
        {
            AgeOfVideosDB aovdb = new AgeOfVideosDB();
            aovdb.Insert(ageOfVideo);
            int x = aovdb.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("MyLikesInserter")]
        public int InsertMyLike([FromBody] MyLikes like)
        {
            MyLikesDB mldb = new MyLikesDB();
            mldb.Insert(like);
            int x = mldb.SaveChanges();
            return x;
        }

    }
}
