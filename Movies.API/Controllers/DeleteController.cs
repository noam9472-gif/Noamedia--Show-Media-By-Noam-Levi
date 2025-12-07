using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers
{
    public class DeleteController : Controller
    {
        // GET: DeleteController
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
