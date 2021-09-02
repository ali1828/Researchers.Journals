using Microsoft.AspNetCore.Mvc;
using Researchers.Journals.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            return RedirectToAction("ViewMyJournal", "Home");
            //return View(loginVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            
            return View(loginVM);
        }
    }
}
