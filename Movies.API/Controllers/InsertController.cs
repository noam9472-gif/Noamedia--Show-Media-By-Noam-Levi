using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers
{
    public class InsertController : Controller
    {
        // GET: InsertController
        public ActionResult Index()
        {
            return View();
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
