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
        [HttpDelete("GenreDeleter/{id}")]
        public int DeleteGenre(int id)
        {
            try
            {
                GenreDB gdb = new();
                gdb.Delete(new Genre { Id = id });
                return gdb.SaveChanges();
            }
            catch { return 0; }
        }
        [HttpDelete("ReviewDeleter/{id}")]
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
    }
}
