using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using XiADSL.Web.Models;

namespace XiADSL.Web.Controllers
{
    public class MetadataController : ApiController
    {
        private readonly HttpServerUtility _server;
        public MetadataController()
        {
            _server = HttpContext.Current.Server;
        }

       public object Get(string v)
        {
            var file = string.Format(_server.MapPath("~/metadata/{0}.json"), v);
            
            if (File.Exists(file))
            {
                var content = File.ReadAllText(file);
                object jsonObject = JsonConvert.DeserializeObject(content);
                return jsonObject;
            }
            
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"content does not exsit");
        }

        public void Post(SaveMetadataModel model)
        {
            var file = _server.MapPath("~/metadata/" + model.Mode + ".json");
            File.WriteAllText(file, model.Meta);
        }
    }
}