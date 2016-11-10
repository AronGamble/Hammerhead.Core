using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco.Core.Services;
using Skrollex.Core.Models;

namespace Skrollex.Core.Controllers
{
    public class GuitarApiController : UmbracoApiController
    {

        public IEnumerable<Guitar> GetAll(string id)
        {
            //var cs = Services.ContentService;
            //var root = cs.GetRootContent().Where(x => x.ContentTypeId == 1052).Single();
            //var about = cs.GetDescendants(root.Id).Where(x => x.ContentTypeId == 1063).Single();

            var g = new Guitar() { Id = 1, Make = "Charvel", Model = "San Dimas" };
            var lg = new List<Guitar>();
            lg.Add(g);

            return lg;
        }
    }
}