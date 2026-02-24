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
        // GET: DeleteController
       [HttpDelete]
       [ActionName("VideoDeleter")]
        public int DeleteVideo(Video vDelete)
        {
            VideoDB vdb = new();
            vdb.Delete(vDelete);
            int z = vdb.SaveChanges();
            return z;
        }
        [HttpDelete]
        [ActionName("UserDeleter")]
        public int DeleteUser(User uDelete)
        {
            UserDB udb = new();
            udb.Delete(uDelete);
            int z = udb.SaveChanges();
            return z;
        }
        [HttpDelete]
        [ActionName("GenreDeleter")]
        public int DeleteGenre(Genre gDelete)
        {
            GenreDB gdb = new();
            gdb.Delete(gDelete);
            int z = gdb.SaveChanges();
            return z;
        }
        [HttpDelete]
        [ActionName("VideoReviewDeleter")]
        public int DeleteVideoReview(VideoReview vrDelete)
        {
            VideoReviewDB vrdb = new();
            vrdb.Delete(vrDelete);
            int z = vrdb.SaveChanges();
            return z;
        }
        [HttpDelete]
        [ActionName("AgeOfVideoDeleter")]
        public int DeleteAgeOfVideo(AgeOfVideos aovDelete)
        {
            AgeOfVideosDB aovdb = new();
            aovdb.Delete(aovDelete);
            int z = aovdb.SaveChanges();
            return z;
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
        [HttpDelete]
        [ActionName("MyLikesDeleter")]
        public int DeleteMyLike(MyLikes likeDelete)
        {
            MyLikesDB mldb = new();
            mldb.Delete(likeDelete);
            int z = mldb.SaveChanges();
            return z;
        }
    }
}
