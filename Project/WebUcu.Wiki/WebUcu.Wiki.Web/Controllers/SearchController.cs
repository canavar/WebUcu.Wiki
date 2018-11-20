using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUcu.Wiki.Operation.DataAccess;

namespace WebUcu.Wiki.Web.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult SearchPages(string searchPhrase)
        {
            ViewData["SearchPhrase"] = searchPhrase;

            var resultPages = DataContext.Current.PageRepository.SelectBySearchPhrase(searchPhrase);

            ViewData["Last10Wikies"] = resultPages;

            return View();
        }
    }
}