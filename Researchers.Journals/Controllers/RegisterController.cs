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
    public class RegisterController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IResearcherRepository _researcherRepository;
        private readonly ResearcherJournalDbContext _dbContext;
        
        public RegisterController(ILoginRepository loginRepository,
            ResearcherJournalDbContext dbContext, IResearcherRepository researcherRepository)
        {
            _loginRepository = loginRepository;
            _researcherRepository = researcherRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult RegisterAsResearcher(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                Researcher researcher = new Researcher();
                researcher.ResearcherName = registerVM.Login.ResearcherName;
                var researcherAdded = _researcherRepository.AddResearcher(researcher).Result;

                if(researcherAdded.ResearcherID > 0)
                {
                    registerVM.Login.ResearcherAddedID = researcherAdded.ResearcherID;
                }

                var result = _loginRepository.CreateLogin(registerVM.Login).Result;
                if(result != null)
                {
                    TempData["SuccessMessage"] = true;
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    TempData["SuccessMessage"] = false;
                    return RedirectToAction("RegisterAsResearcher", "Register");
                }
            }
            else
            {
                TempData["SuccessMessage"] = false;
                return RedirectToAction("RegisterAsResearcher", "Register");
            }
        }

        [HttpGet]
        public IActionResult RegisterAsResearcher()
        {
            RegisterVM registerVM = new RegisterVM();
            ViewBag.Success = TempData["SuccessMessage"] as bool?;
            return View(registerVM);
        }
    }
}
