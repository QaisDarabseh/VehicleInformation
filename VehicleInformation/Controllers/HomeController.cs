using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleInformation.Models;
using VehicleInformation.Services.Interfaces;

namespace VehicleInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleApiService _vehicleApiService;

        public HomeController(IVehicleApiService vehicleApiService)
        {
            _vehicleApiService = vehicleApiService;
        }

        public async Task<IActionResult> Index()
        {
            var makes = await _vehicleApiService.GetAllMakesAsync();
            return View(makes);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            var types = await _vehicleApiService.GetVehicleTypesForMakeAsync(makeId);
            return Json(types);
        }

        [HttpGet]
        public async Task<IActionResult> GetModels(int makeId, int year)
        {
            var models = await _vehicleApiService.GetModelsAsync(makeId, year);
            return Json(models);
        }

    }
}
