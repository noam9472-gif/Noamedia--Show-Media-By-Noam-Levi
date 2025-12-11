using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noamedia__Show_Media_By_Noam_Levi;
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
