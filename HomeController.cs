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
        static MurderSuspect suspect;




        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            suspect = dal.GetRandomFromList();
            ViewBag.ClueOne = dal.GetClueOne(suspect);
            ViewBag.ClueTwo = dal.GetClueTwo(suspect);
            ViewBag.ClueThree = dal.GetClueThree(suspect);

            return View("Index", dal.GetSuspects());
        }

        


        [HttpGet]
        public IActionResult AddSuspect()
        {
            return View("SuspectForm");
        }

        
        [HttpPost]
      
        public IActionResult Index(string guess)
        {
            

            
            ViewBag.ClueOne = dal.GetClueOne(suspect);
            ViewBag.ClueTwo = dal.GetClueTwo(suspect);
            ViewBag.ClueThree = dal.GetClueThree(suspect);

            
            
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
