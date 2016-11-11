using Skrollex.Core.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
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
            //if (!ModelState.IsValid)
            //{
            //    TempData.Add("ValidationMessage", "Please complete the form");
            //    return CurrentUmbracoPage();
            //}

            var cs = Services.ContentService;
            var cts = Services.ContentTypeService;

            // Get the Id of the Contact Doc Type
            var contactType = cts.GetContentType("Contact");

            // Get the Contact page
            var contactPage = cs.GetContentOfContentType(contactType.Id).FirstOrDefault();

            var newContactItem = cs.CreateContent(model.Name, contactPage.Id, "contactItem");

            newContactItem.SetValue("contactName", model.Name);
            newContactItem.SetValue("email", model.Email);
            newContactItem.SetValue("message", model.Message);

            cs.Save(newContactItem);

            // TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now);

            return RedirectToCurrentUmbracoPage();

        }
    }
}