using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
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
        [ActionName("VideoReviewUpdater")]
        public int UpdateVideoReview([FromBody] VideoReview videoReview)
        {
            VideoReviewDB vrdb = new VideoReviewDB();
            vrdb.Update(videoReview);
            int x = vrdb.SaveChanges();
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
            UserPremiumDB urdb = new UserPremiumDB();
            urdb.Update(userPremium);
            int x = urdb.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("AgeOfVideoUpdater")]
        public int UpdateAgeOfVideo([FromBody] AgeOfVideo ageOfVideo)
        {
            AgeOfVideoDB aovdb = new AgeOfVideoDB();
            aovdb.Update(ageOfVideo);
            int x = aovdb.SaveChanges();
            return x;
        }


        // GET: UpdateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateController/Create
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

        // GET: UpdateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateController/Edit/5
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

        // GET: UpdateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateController/Delete/5
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
