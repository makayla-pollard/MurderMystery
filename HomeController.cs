using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MurderMystery.Data;
using MurderMystery.Interfaces;
using MurderMystery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMystery.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        IDataAccessLayer dal = new SuspectListDAL();

        
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {

            return View("Index", dal.GetSuspects());
        }

        


        [HttpGet]
        public IActionResult AddSuspect()
        {
            return View("SuspectForm");
        }

        
        [HttpPost]
        //NOT WORKING BECAUSE IT'S STUPID
        public IActionResult Index(MurderSuspect suspect)
        {
            //random = dal.GetRandomFromList();
            //ViewBag.Random = random;

            suspect = dal.GetRandomFromList();
            ViewBag.ClueOne = dal.GetClueOne(suspect);
            ViewBag.ClueTwo = dal.GetClueTwo(suspect);
            ViewBag.ClueThree = dal.GetClueThree(suspect);

            
            var guess = HttpContext.Request.Form["Check"];
            ViewBag.Check = dal.CheckSuspect(suspect, guess);
            
            
            return View("Index", dal.GetSuspects());
        }

        public IActionResult AddSuspect(MurderSuspect suspect)
        {
            if(ModelState.IsValid)
            {
                dal.AddSuspect(suspect);
                return Redirect("Index");
            }
            return View("SuspectForm", suspect );
        }

        

        //public IActionResult GamePlay()
        //{
            
        //    dal.SetMurderer(dal.GetRandomFromList());
        //    var murderer = dal.GetMuderer();
        //    ViewBag.ClueOne = dal.GetClueOne(murderer);
        //    ViewBag.ClueTwo = dal.GetClueTwo(murderer);
        //    ViewBag.ClueThree = dal.GetClueThree(murderer);
        //    var guess = dal.GetMuderer().Guess;
        //    ViewBag.Check = dal.CheckSuspect(murderer, guess);
        //    return View("Index", dal.GetSuspects());
        //}
        
        
        public IActionResult DeleteSuspect(int? id)
        {
            dal.DeleteSuspect(id);
            return View("Index", dal.GetSuspects());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
