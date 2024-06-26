using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicle _vehicle;
        public VehiclesController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public ActionResult Adm()
        {
            var models = _vehicle.GetAll();
            return View(models); 
        }

        public ActionResult VehicleDetail(string id)
        {
            var vehicle = _vehicle.GetById(id);
            return View(vehicle);
        }

        // GET: VehiclesController
        public ActionResult Index()
        {
            //var models = _vehicle.GetAllAvailableVehicles();
            var models = _vehicle.GetAll();
            return View(models);
        }

        // GET: VehiclesController/Details/5
        public ActionResult Details(string id)
        {
            var vehicle = _vehicle.GetById(id);
            return View(vehicle);
        }

        // GET: VehiclesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiclesController/Create
        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                var result = _vehicle.Add(vehicle);
                return RedirectToAction(nameof(Adm));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ViewBag.ErrorMessage = $"Failed to create vehicle: {ex.Message}";
                return View(vehicle);
            }
        }

        // GET: VehiclesController/Edit/5
        public ActionResult Edit(string id)
        {
            var vehicle = _vehicle.GetById(id);
            return View(vehicle);
        }

        // POST: VehiclesController/Edit/5
        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            try
            {
                var result = _vehicle.Update(vehicle);

                TempData["Message"] = $"Vehicle {vehicle.Make} - {vehicle.Model} updated successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Vehicle not updated";
                return View();
            }
        }

        // GET: VehiclesController/Delete/5
        public ActionResult Delete(string id)
        {
            var vehicle = _vehicle.GetById(id);
            return View(vehicle);
        }

        // POST: VehiclesController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(string Vehicleid)
        {
            try
            {
                _vehicle.Delete(Vehicleid);
                TempData["Message"] = $"Vehicle {Vehicleid} deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ViewBag.ErrorMessage = $"Failed to delete vehicle: {ex.Message}";
                return View();
            }
        }
    }
}
