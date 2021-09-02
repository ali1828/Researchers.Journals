using Microsoft.AspNetCore.Mvc;
using Researchers.Journals.Models;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;
using Researchers.Journals.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ResearcherJournalDbContext _dbContext;

        public LoginController(ILoginRepository loginRepository,
            ResearcherJournalDbContext dbContext)
        {
            _loginRepository = loginRepository;
            _dbContext = dbContext;
        }


        public static Login CurrentReasearcherLogin { get; set; }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
                var result = _loginRepository.GetLoginDetails(loginVM.Login).Result;
                if (result != null)
                {
                    CurrentReasearcherLogin = result;
                    TempData["SuccessMessage"] = true;
                    return RedirectToAction("ViewMyJournal", "Home");
                }
                else
                {
                    TempData["SuccessMessage"] = false;
                    return RedirectToAction("Login", "Login");
                }
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            ViewBag.Success = TempData["SuccessMessage"] as bool?;
            return View(loginVM);
        }
    }
}
