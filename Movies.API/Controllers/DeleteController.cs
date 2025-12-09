using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noamedia__Show_Media_By_Noam_Levi
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
        [ActionName("VideoSelector")]
        public VideoList DeleteVideo()
        {
            VideoDB vdb = new();
            VideoList vList = vdb.SelectAll();
            foreach (Video v in vList)
                Console.WriteLine(v.VideoName);
            Video vDelete = vList.Last();
            vdb.Delete(vDelete);
            int z = vdb.SaveChanges();
            Console.WriteLine($"{z} rows were deleted");
            foreach (Video v in vList)
                Console.WriteLine(v);
            Console.WriteLine();
        }
        [HttpDelete]
        [ActionName("UserSelector")]
        public UserList SelectAllUsers()
        {
            UserDB db = new UserDB();
            UserList videos = db.SelectAll();
            return videos;
        }
        [HttpDelete]
        [ActionName("GenreSelector")]
        public GenreList SelectAllGenres()
        {
            GenreDB db = new GenreDB();
            GenreList genres = db.SelectAll();
            return genres;
        }
        [HttpDelete]
        [ActionName("VideoReviewSelector")]
        public VideoReviewList SelectAllVideoReviews()
        {
            VideoReviewDB db = new VideoReviewDB();
            VideoReviewList videoReviews = db.SelectAll();
            return videoReviews;
        }
        [HttpDelete]
        [ActionName("AgeOfVideoSelector")]
        public AgeOfVideoList SelectAllAgeOfVideos()
        {
            AgeOfVideosDB db = new AgeOfVideosDB();
            AgeOfVideoList ageOfVideos = db.SelectAll();
            return ageOfVideos;
        }
        [HttpDelete]
        [ActionName("UserPremiumSelector")]
        public UserPremiumList SelectAllUserPremiums()
        {
            UserPremiumDB db = new UserPremiumDB();
            UserPremiumList movies = db.SelectAll();
            return movies;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeleteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeleteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeleteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeleteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeleteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
