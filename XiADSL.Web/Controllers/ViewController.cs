using System.Net;
using System.Web.Mvc;

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
    }
}