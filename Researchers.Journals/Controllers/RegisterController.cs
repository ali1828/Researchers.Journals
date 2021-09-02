using Microsoft.AspNetCore.Mvc;
using Researchers.Journals.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult RegisterAsResearcher()
        {
            RegisterVM registerVM = new RegisterVM();
            return View(registerVM);
        }

        [HttpPost]
        public IActionResult RegisterAsResearcher(RegisterVM registerVM)
        {
            return RedirectToAction("Login", "Login");
            //return View(registerVM);
        }
    }
}
