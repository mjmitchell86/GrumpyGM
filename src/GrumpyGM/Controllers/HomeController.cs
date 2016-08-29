using Microsoft.AspNetCore.Mvc;
using GrumpyGM.DataLayer.Models;
using GrumpyGM.ViewModels;
using GrumpyGM.Services.Interfaces;
using System.Threading;

namespace GrumpyGM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGrumpyGMService _grumpyService;

        public HomeController(IGrumpyGMService grumpService)
        {
            _grumpyService = grumpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Taunts()
        {
            ViewData["Message"] = "Enter your taunts here.";
            var xuTauntVM = new GMTauntAddShow();
            xuTauntVM.Taunts = _grumpyService.GetTauntsContent();
            return View(xuTauntVM);
        }

        [HttpPost]
        public IActionResult AddTaunt(GrumpyGMTaunt taunt)
        {
            _grumpyService.SaveTaunt(taunt);
            Thread.Sleep(1800);
            return RedirectToAction("Taunts");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
