using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoice _invoice;

        public InvoiceController(IInvoice invoice)
        {
            _invoice = invoice;
        }
        
        // GET: InvoicesController
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Invoice> invoices;
            invoices = _invoice.GetAll();
            return View(invoices);
        }

        // GET: InvoicesController/Details/5
        public ActionResult Details(string id)
        {
            var invoice = _invoice.GetById(id);
            return View(invoice);
        }

        // GET: InvoicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoicesController/Create
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

        // GET: InvoicesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoicesController/Edit/5
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

        // GET: InvoicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoicesController/Delete/5
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
