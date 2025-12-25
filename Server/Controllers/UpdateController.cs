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
        // GET: UpdateController
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
        [HttpPut]
        [ActionName("AgeOfVideoUpdater")]
        public int UpdateAgeOfAgeOfVideo([FromBody] AgeOfVideos ageOfVideo)
        {
            AgeOfVideosDB aovdb = new AgeOfVideosDB();
            aovdb.Update(ageOfVideo);
            int x = aovdb.SaveChanges();
            return x;
        }
    }
}
