using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUcu.Wiki.Operation.DataAccess;
using WebUcu.Wiki.Web.Models;

namespace WebUcu.Wiki.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var lastWikies = DataContext.Current.PageRepository.SelectLastWikies();
            ViewData["Last10Wikies"] = lastWikies;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
