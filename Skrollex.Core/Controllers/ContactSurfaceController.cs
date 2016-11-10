using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco.Core.Services;
using Skrollex.Core.Models;
using Umbraco.Web.Mvc;

namespace Skrollex.Core.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactFormViewModel());
        }

        [HttpPost]
        public ActionResult CreateContact(ContactFormViewModel model)
        {
            //model not valid, do not save, but return current Umbraco page
            //if (!ModelState.IsValid)
            //{
            //    //Perhaps you might want to add a custom message to the ViewBag
            //    //which will be available on the View when it renders (since we're not 
            //    //redirecting)          
            //    return CurrentUmbracoPage();
            //}

            //if validation passes perform whatever logic
            //In this sample we keep it empty, but try setting a breakpoint to see what is posted here

            //Perhaps you might want to store some data in TempData which will be available 
            //in the View after the redirect below. An example might be to show a custom 'submit
            //successful' message on the View, for example:
            TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now);

            //redirect to current page to clear the form
            return RedirectToCurrentUmbracoPage();

            //Or redirect to specific page
            //return RedirectToUmbracoPage(12345)
        }


    }
}