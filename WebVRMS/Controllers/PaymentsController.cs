using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPayment _payment;

        public PaymentsController(IPayment payment)
        {
            _payment = payment;
        }

        // GET: PaymentsController
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Payment> payments;
            payments = _payment.GetAll();
            return View(payments);
        }

        // GET: PaymentsController/Details/5
        public ActionResult Details(string id)
        {
            var payment = _payment.GetById(id);
            return View(payment);
        }

        // GET: PaymentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentsController/Create
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

        // GET: PaymentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentsController/Edit/5
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

        // GET: PaymentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentsController/Delete/5
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
