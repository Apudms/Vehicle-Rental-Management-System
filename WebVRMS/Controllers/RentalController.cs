using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRental _rental;

        public RentalController(IRental rental)
        {
            _rental = rental;
        }

        // GET: RentalController
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Rental> rentals;
            rentals = _rental.GetAll();
            return View(rentals);
        }

        // GET: RentalController/Details/5
        public ActionResult Details(string id)
        {
            var rental = _rental.GetById(id);
            return View(rental);
        }

        // GET: RentalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalController/Create
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

        // GET: RentalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentalController/Edit/5
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

        // GET: RentalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentalController/Delete/5
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
