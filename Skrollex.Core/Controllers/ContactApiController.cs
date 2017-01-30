using Skrollex.Core.Models;
using System.Linq;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace Skrollex.Core.Controllers
{
    public class ContactApiController : UmbracoApiController
    {

        [HttpPost]
        public string PostContact([FromBody]ContactFormViewModel model)
        {
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

            return "success";
        }
    }
}