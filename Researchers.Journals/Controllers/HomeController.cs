using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Researchers.Journals.Models;
using Researchers.Journals.Models.Data;
using Researchers.Journals.Models.Interfaces;
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
        private readonly ILoginRepository _loginRepository;
        private readonly IJournalsRepository _journalsRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IResearcherRepository _researcherRepository;
        private readonly ResearcherJournalDbContext _dbContext;



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginRepository,
            IJournalsRepository journalsRepository, ISubscriberRepository subscriberRepository,
            IResearcherRepository researcherRepository, ResearcherJournalDbContext dbContext)
        {
            _logger = logger;
            _loginRepository = loginRepository;
            _journalsRepository = journalsRepository;
            _subscriberRepository = subscriberRepository;
            _researcherRepository = researcherRepository;
            _dbContext = dbContext;
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
           var result = _journalsRepository.GetJournalsByResearcherID(LoginController.CurrentReasearcherLogin.ResearcherAddedID).Result;
            ViewMyJournalVM viewMyJournalVM = new ViewMyJournalVM();
            if(result != null)
            {
                viewMyJournalVM.MyJournals.AddRange(result);
            }
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
            var result = _researcherRepository.GetResearcher().Result;
            SubscribeToResearcherVM subscribeToResearcherVM = new SubscribeToResearcherVM();
            if(result?.Count > 0)
            {
                var tempRes = result.Where(p => p.ResearcherID != LoginController.CurrentReasearcherLogin.ResearcherAddedID).ToList();
                subscribeToResearcherVM.ResearchersToSubscribed = tempRes;
            }
            ViewBag.Success = TempData["SuccessMessage"] as bool?;
            return View(subscribeToResearcherVM);
        }

        [HttpPost]
        public IActionResult SubscribeToResearcher(SubscribeToResearcherVM subscribeToResearcherVM)
        {

            if (ModelState.IsValid)
            {
                List<Subscribers> tempList = new List<Subscribers>();
                foreach (var item in subscribeToResearcherVM.ResearchersToSubscribed)
                {
                    var allJournalsByThisResearcher =_journalsRepository.GetJournalsByResearcherID(item.ResearcherID).Result;
                    foreach (var allJournals in allJournalsByThisResearcher)
                    {
                        Subscribers tempSub = new Subscribers();
                        tempSub.JournalID = allJournals.JournalID;
                        tempSub.ResearcherID = allJournals.ResearcherID;
                        tempSub.SubscriberAsResearcherID = LoginController.CurrentReasearcherLogin.ResearcherAddedID;
                        tempList.Add(tempSub);
                    }
                }


               var resultAfterUpdate = _subscriberRepository.CreateSubscribedJournals(tempList).Result ;
               if(resultAfterUpdate != null)
                {
                    TempData["SuccessMessage"] = true;
                }
               else
                {
                    TempData["SuccessMessage"] = false;
                }
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
            var result =_subscriberRepository.GetSubscribedResearchersById
                (LoginController.CurrentReasearcherLogin.Id).Result;
            if(result != null)
            {
                foreach (var item in result)
                {
                    Researchers.Journals.Models.Journals tempJournal
                                 = new Researchers.Journals.Models.Journals();

                    tempJournal = _journalsRepository.GetJournalByJournalID(item.JournalID).Result;

                    var researcherFound =_researcherRepository.GetResearcherByResearcherID(item.SubscriberAsResearcherID).Result;
                    tempJournal.Researcher = researcherFound;
                    viewSubscribedJournalsVM.SubscribedJournals.Add(tempJournal);
                }

            }
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
                            uploadJournalVM.Journal.ResearcherID = LoginController.CurrentReasearcherLogin.ResearcherAddedID;
                            var CreatedJournal = _journalsRepository.CreateJournal(uploadJournalVM.Journal).Result;
                            if(CreatedJournal != null && CreatedJournal.JournalID > 0)
                            {
                                //Insert by default first journal upon successfull uploading
                                List<Subscribers> subscribers = new List<Subscribers>();

                                Subscribers subscriberToInsert = new Subscribers();
                                subscriberToInsert.JournalID = CreatedJournal.JournalID;
                                subscriberToInsert.ResearcherID = uploadJournalVM.Journal.ResearcherID;
                                subscriberToInsert.SubscriberAsResearcherID = uploadJournalVM.Journal.ResearcherID;

                                subscribers.Add(subscriberToInsert);
                                var addedNewSubscriber =
                                    _subscriberRepository.CreateSubscribedJournals(subscribers).Result;
                                if(addedNewSubscriber?.Count > 0)
                                {
                                    TempData["SuccessMessage"] = true;
                                }
                                else
                                {
                                    TempData["SuccessMessage"] = false;
                                }
                            }
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

            return RedirectToAction("JournalView", "Home",
                new { id = viewJournalVM.MyJournal.JournalID });
        }


        [HttpGet]
        public FileResult JournalView(int id)
        {
            if(id > 0)
            {
                var result = _journalsRepository.GetJournalByJournalID(id).Result;
                if(result != null)
                {
                    return File(result.JournalDocument, "application/pdf",
                            result.JournalName);
                }
                else
                {

                }
            }
            return File("", "application/pdf","Unabled to get");
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
