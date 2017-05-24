using Microsoft.AspNetCore.Mvc;
using GrumpyGM.Services.Interfaces;
using GrumpyGM.ViewModels;
using GrumpyGM.DataLayer.Models;
using System.Threading;
using System.Collections.Generic;

namespace GrumpyGM.Controllers
{
    public class QuizController : Controller
    {
        private readonly IGrumpyQuizService _grumpyQuizService;

        public QuizController(IGrumpyQuizService grumpyQuizService)
        {
            _grumpyQuizService = grumpyQuizService;
        }

        public IActionResult WakeUp()
        {
            ViewData["Message"] = "Wake Up Phrases.";
            var xuVM = new WakeUpViewModel() { WakeUpPhrases = _grumpyQuizService.GetWakeUpPhrases() ?? new List<WakeUpPhrase>() };
            return View(xuVM);
        }

        public IActionResult CorrectResponses()
        {
            ViewData["Message"] = "Correct Answer Responses.";
            var xuVM = new CorrectAnswerViewModel() { CorrectResponses = _grumpyQuizService.GetCorrectResponses() ?? new List<CorrectResponse>() };
            return View(xuVM);
        }

        public IActionResult WrongResponses()
        {
            ViewData["Message"] = "Wrong Answer Responses.";
            var xuVM = new WrongAnswerViewModel() { WrongResponses = _grumpyQuizService.GetWrongResponses() ?? new List<WrongResponse>()};
            return View(xuVM);
        }

        public IActionResult PerfectResponses()
        {
            ViewData["Message"] = "We want all your quiz nonsense.";
          //  var xuVM = new WrongAnswerViewModel() { WrongResponses = _grumpyQuizService.GetWrongResponses() ?? new List<WrongResponse>() };
            return View();
        }

        [HttpPost]
        public IActionResult AddPhrase(string phrase)
        {
            _grumpyQuizService.SaveWakeUpPhrase(phrase);
            Thread.Sleep(1000);
            return RedirectToAction("WakeUp");
        }

        [HttpPost]
        public IActionResult AddCorrectResponse(string response, bool lastQuestionRespose)
        {
            _grumpyQuizService.saveCorrectResponse(response, lastQuestionRespose);
            Thread.Sleep(1000);
            return RedirectToAction("CorrectResponses");
        }

        [HttpPost]
        public IActionResult AddWrongResponse(string response, bool lastQuestionRespose)
        {
            _grumpyQuizService.saveWrongResponse(response, lastQuestionRespose);
            Thread.Sleep(1000);
            return RedirectToAction("WrongResponses");
        }
    }
}
