using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noamedia__Show_Media_By_Noam_Levi;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
    public class InsertController : Controller
    {
        // GET: InsertController
        [HttpPost]
        [ActionName("VideoInserter")]
        public int InsertVideo([FromBody] Video video)
        {
            VideoDB vdb = new VideoDB();
            vdb.Insert(video);
            int x = vdb.SaveChanges();
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
        [ActionName("UserInserter")]
        public int InsertUser([FromBody] User user)
        {
            UserDB udb = new UserDB();
            udb.Insert(user);
            int x = udb.SaveChanges();
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
        [ActionName("GenreInserter")]
        public int InsertGenre([FromBody] Genre genre)
        {
            GenreDB gdb = new GenreDB();
            gdb.Insert(genre);
            int x = gdb.SaveChanges();
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


        // GET: InsertController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsertController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsertController/Create
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

        // GET: InsertController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsertController/Edit/5
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

        // GET: InsertController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsertController/Delete/5
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
