using System.Net;
using System.Web.Mvc;
using XiADSL.Web.Models;

namespace XiADSL.Web.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Index(string v)
        {
            var file = string.Format(Server.MapPath("~/metadata/{0}.json"), v);
            if (System.IO.File.Exists(file))
                return File(file, "application/json");
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
        [HttpPost]
        public void SaveMeta(SaveMetadataModel model)
        {
            var file = System.Web.HttpContext.Current.Server.MapPath("~/metadata/" + model.Mode + ".json");
            System.IO.File.WriteAllText(file, model.Meta);
        }
    }
}