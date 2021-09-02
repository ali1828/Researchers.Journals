using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Researchers.Journals.Models;
using Researchers.Journals.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace Researchers.Journals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ViewMyJournal()
        {
            ViewMyJournalVM viewMyJournalVM = new ViewMyJournalVM();
            return View(viewMyJournalVM);
        }

        [HttpPost]
        public IActionResult ViewMyJournal(ViewMyJournalVM viewMyJournalVM)
        {
            return View(viewMyJournalVM);
        }


        [HttpPost]
        public IActionResult ViewMySingleJournal(ViewMyJournalVM viewMyJournalVM)
        {
            return View(viewMyJournalVM);
        }


        [HttpGet]
        public IActionResult SubscribeToResearcher()
        {
            SubscribeToResearcherVM subscribeToResearcherVM = new SubscribeToResearcherVM();
            ViewBag.Success = TempData["SuccessMessage"] as bool?;
            return View(subscribeToResearcherVM);
        }

        [HttpPost]
        public IActionResult SubscribeToResearcher(SubscribeToResearcherVM subscribeToResearcherVM)
        {

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = true;
                return RedirectToAction("SubscribeToResearcher", "Home");
            }
            else
            {
                TempData["SuccessMessage"] = false;
                return RedirectToAction("SubscribeToResearcher", "Home");
            }

            // return View(subscribeToResearcherVM);
        }



        public IActionResult BtnCancelSubscribeToResearchers()
        {
            return RedirectToAction("ViewMyJournal", "Home");
        }


        [HttpGet]
        public IActionResult ViewSubscribedJournals()
        {
            ViewSubscribedJournalsVM viewSubscribedJournalsVM = new ViewSubscribedJournalsVM();
            return View(viewSubscribedJournalsVM);
        }


        [HttpGet]
        public IActionResult UploadJournal()
        {
            UploadJournalVM uploadJournalVM = new UploadJournalVM();
            ViewBag.Success = TempData["SuccessMessage"] as bool?;
            return View(uploadJournalVM);
        }

        public bool ValidateUploadedData(UploadJournalVM uploadJournalVM)
        {
            try
            {
                if (uploadJournalVM?.Journal != null && uploadJournalVM?.File != null)
                {
                    var fileExtension = Path.GetExtension(uploadJournalVM?.File.FileName);
                    if (!string.IsNullOrEmpty(uploadJournalVM.Journal.JournalName) &&
                    uploadJournalVM.File.Length > 0 && uploadJournalVM.File.FileName != null
                    && fileExtension == ".pdf")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [HttpPost]
        public IActionResult UploadJournal(UploadJournalVM uploadJournalVM)
        {
            bool IsValidated = ValidateUploadedData(uploadJournalVM);

            if (IsValidated)
            {
                if (uploadJournalVM.File.FileName != null)
                {
                    if (uploadJournalVM.File.Length > 0)
                    {

                        var fileName = Path.GetFileName(uploadJournalVM.File.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        if (fileExtension == ".pdf")
                        {
                            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                            Byte[] data = new byte[uploadJournalVM.File.Length];
                            uploadJournalVM.Journal.JournalDocument = data;

                            TempData["SuccessMessage"] = true;
                            return RedirectToAction("UploadJournal");
                        }
                        else
                        {
                            TempData["SuccessMessage"] = false;
                            return RedirectToAction("UploadJournal");
                        }
                    }
                }
            }
            else
            {
                TempData["SuccessMessage"] = false;
                return RedirectToAction("UploadJournal");
            }
            return View();
        }


        [HttpPost]
        public IActionResult JournalView(ViewJournalVM viewJournalVM)
        {
            ViewSubscribedJournalsVM viewSubscribedJournalsVM = new ViewSubscribedJournalsVM();

            RedirectToAction("JournalView", "Home",
                new { id = viewJournalVM.MyJournal.JournalID });

            return View(viewSubscribedJournalsVM);
        }


        [HttpGet]
        public FileResult JournalView(int id)
        {
            ViewJournalVM viewJournalVM = new ViewJournalVM();

            return File(viewJournalVM.MyJournal.JournalDocument, "application/pdf",
                viewJournalVM.MyJournal.JournalName);

        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
