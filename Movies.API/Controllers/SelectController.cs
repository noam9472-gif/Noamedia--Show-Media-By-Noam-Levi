using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
    public class SelectController : Controller
    {
        // GET: SelectController
        [HttpGet]
        [ActionName("MoviesSelector")]
        public VideoList SelectAllVideos()
        {
            VideoDB db = new VideoDB();
            VideoList videos = db.SelectAll();
            return videos;
        }
        public UserList SelectAllUsers()
        {
            UserDB db = new UserDB();
            UserList videos = db.SelectAll();
            return videos;
        }
        public GenreList SelectAllGenres()
        {
            GenreDB db = new GenreDB();
            GenreList genres = db.SelectAll();
            return genres;
        }
        public VideoReviewList SelectAllVideoReviews()
        {
            VideoReviewDB db = new VideoReviewDB();
            VideoReviewList videoReviews = db.SelectAll();
            return videoReviews;
        }
        public AgeOfVideoList SelectAllAgeOfVideos()
        {
            AgeOfVideosDB db = new AgeOfVideosDB();
            AgeOfVideoList ageOfVideos = db.SelectAll();
            return ageOfVideos;
        }
        public UserPremiumList SelectAllUserPremiums()
        {
            UserPremiumDB db = new UserPremiumDB();
            UserPremiumList movies = db.SelectAll();
            return movies;
        }
        [HttpGet]
        [ActionName("MovieSelector")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: SelectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelectController/Create
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

        // GET: SelectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelectController/Edit/5
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

        // GET: SelectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectController/Delete/5
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
