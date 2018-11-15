using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUcu.Wiki.Operation.DataAccess;
using WebUcu.Wiki.Operation.Entities;

namespace WebUcu.Wiki.Web.Controllers
{
    public class WikiController : Controller
    {
        public WikiController()
        {
        }
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Edit(long id)
        {
            Page page = DataContext.Current.PageRepository.SelectById(id);

            return View(page);
        }

        public IActionResult EditPage(Page editedPage)
        {
            editedPage.ModifyDate = DateTime.Now;
            editedPage.ModifiedBy = "TODO";
            editedPage.VersionNumber++;

            DataContext.Current.PageRepository.Edit(editedPage);

            ViewData["Message"] = "Page edit succesfully saved!";
            return View("Edit", editedPage);
        }

        public IActionResult NewPage()
        {
            ViewData["Message"] = "New Page";

            return View();
        }

        public IActionResult CreateNewPage(Page newPage)
        {
            newPage.CreateDate = DateTime.Now;
            newPage.CreatedBy = "TODO";
            newPage.ModifyDate = DateTime.Now;
            newPage.ModifiedBy = "TODO";
            newPage.VersionNumber = 1;

            DataContext.Current.PageRepository.Add(newPage);

            // TODO : redirect to listing page : 
            ViewData["Message"] = "New Page";

            return View();
        }

        public IActionResult ViewPage(long id)
        {
            Page page = DataContext.Current.PageRepository.SelectById(id);
            
            // TODO : redirect to listing page : 
            ViewData["Message"] = "New Page";

            return View(page);
        }
    }
}