using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using webLab2._1.Models;

namespace webLab2._1.Controllers
{
    public class MockupsController : Controller
    {
        private readonly ILogger<MockupsController> _logger;

        public MockupsController(ILogger<MockupsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult PassReset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PassReset(Data User, string action)
        {
            if (ModelState["Email"].ValidationState == ModelValidationState.Valid)
            {
                if (action == "Send me a code")
                {
                    ViewBag.Code = "Your code: " + User.Code;
                    return View(User);
                }
                return Redirect("Confirm");
            }
            return View();
        }

        public IActionResult Confirm(string Value)
        {
            Data User = new Data();
            if (Request.Method == "POST")
            {
                if ((User.Code).ToString() == Value)
                    ViewBag.Check = "You can Reset your Password";
                else
                    ViewBag.Check = "Wrong code";
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Data inf)
        {
            if (ModelState["FirstName"].ValidationState == ModelValidationState.Valid &
                ModelState["LastName"].ValidationState == ModelValidationState.Valid &
                ModelState["Gender"].ValidationState == ModelValidationState.Valid)
                return RedirectToAction("SignUpCont", inf);
            return View();
        }
        [HttpGet]
        public IActionResult SignUpCont()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUpCont(Data inf)
        {

            if (ModelState["Email"].ValidationState == ModelValidationState.Valid &
                ModelState["Password"].ValidationState == ModelValidationState.Valid &
                ModelState["ComparePassword"].ValidationState == ModelValidationState.Valid)
                return View("Result", inf);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
