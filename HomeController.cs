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
            return View();
        }


        [HttpGet]
        public IActionResult AddSuspect()
        {
            return View("SuspectForm");
        }

        [HttpPost]
        public IActionResult AddSuspect(MurderSuspect suspect)
        {
            if(ModelState.IsValid)
            {
                dal.AddSuspect(suspect);
                return Redirect("Index");
            }
            return View("SuspectForm", suspect );
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
