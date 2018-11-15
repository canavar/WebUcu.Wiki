using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUcu.Wiki.Operation.DataAccess;

namespace WebUcu.Wiki.Web.Controllers
{
    public class TagsController : Controller
    {
        public IActionResult TagPages(string tag)
        {
            ViewData["Tag"] = tag;

            var taggedPages = DataContext.Current.PageRepository.SelectByTag(tag);

            return View(taggedPages);
        }
    }
}