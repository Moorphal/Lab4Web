using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webLab2._1.Models;

namespace webLab2._1.Controllers
{
    public class ControlsServiceController : Controller
    {
        private readonly Random _random = new Random();                

        private readonly ILogger<ControlsServiceController> _logger;

        public ControlsServiceController(ILogger<ControlsServiceController> logger)
        {
            _logger = logger;                    
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult TextBox(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "Text Box";
                ViewBag.Name = "Text";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }

        public IActionResult TextArea(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "Text Area";
                ViewBag.Name = "Text";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }

        public IActionResult CheckBox(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "Check Box";
                ViewBag.Name = "IsSelected";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }
        public IActionResult Radio(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "Radio";
                ViewBag.Name = "Month";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }

        public IActionResult DropDownList(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "Drop-Down List";
                ViewBag.Name = "Month";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }

        public IActionResult ListBox(string State)
        {


            if (Request.Method == "POST")
            {
                ViewBag.Type = "List Box";
                ViewBag.Name = "Month";
                ViewBag.Value = State;
                return View("Result");
            }
            else
                return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Quiz()
        {
            QuizModel qModel = QuizModel.Instance;
            qModel.Reset();
            qModel.Start();


            return View(qModel);
        }

        [HttpPost]
        public IActionResult Quiz(QuizModel qModel, string action)
        {
            qModel = QuizModel.Instance;

            if (Request.Form["Answer"] != "") qModel.UserAnswer = Int32.Parse(Request.Form["Answer"]);
            else qModel.UserAnswer = 0;
            qModel.Questions();



            if (action == "Next")
            {
                QuizModel quModel = QuizModel.Instance;
                quModel.Start();

                return View(quModel);
            }
            return RedirectToAction("QuizResult");            

        }
        public IActionResult QuizResult()
        {
            QuizModel qModel = QuizModel.Instance;
            ViewBag.Result = qModel.AllAnswers;
            ViewData["Всего"] = "" + qModel.Count;
            ViewData["Правильно"] = "" + qModel.CountOfRightAnswers;
            return View();
        }                
    }
}