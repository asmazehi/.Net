using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _flightService;
        public FlightController(IServiceFlight flightService)
        {
            _flightService = flightService;
        }


        public IActionResult Index(DateTime? dateDepart)
        {
            var flights = _flightService.GetAll().ToList();
            return View(flights);
        }
        public IActionResult Details(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _flightService.Add(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }
        public IActionResult Edit(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _flightService.Update(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }
        public IActionResult Delete(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight != null)
            {
                _flightService.Delete(flight);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }

}