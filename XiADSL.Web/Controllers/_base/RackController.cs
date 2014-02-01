using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XiADSL.Arc;
using XiADSL.Web.Models;

namespace XiADSL.Web.Controllers._base
{


    public class RackController<T> : ApiController where T : BaseModel, new()
    {

        readonly IRepository<T> _repository;
        public RackController(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Get(int id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<T> Select()
        {
            return _repository.Query;
        }

        public virtual HttpResponseMessage Post(T item)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public void Put(T item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }



        [HttpGet]
        public string CreateMeta(string fileName)
        {
            int i = 1;
            var meta = typeof(T).GetProperties().Where(x => (!x.Name.EndsWith("Id")) || x.Name == "Id").Select(x => new ViewMetadata(x)
            {
                UName = x.Name,
                Row = i++,
            });
            var file = HttpContext.Current.Server.MapPath("~/metadata/" + fileName + ".json");

            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var content = JsonConvert.SerializeObject(meta, Formatting.Indented, jsonSerializerSettings);

            File.WriteAllText(file, content);
            return content;

        }

        


        [HttpGet]
        public IEnumerable<KeyValueLookup> Lookup(string text)
        {

            //var rep = _repository as IQueryRepository<BaseNameModel>;

            return _repository.Query
                //.Where(x=>x.Name.StartsWith(text))
                .Select(LookupProjection);

        }

        internal virtual KeyValueLookup LookupProjection(T arg)
        {
            var c = arg as BaseNameModel;
            if (c != null)
                return new KeyValueLookup { Name = c.Name, Id = c.Id };



            //return arg;
            throw new Exception(string.Format("Unspecified Type,please provide projection method for type [{0}]", typeof(T).Name));
        }


    }
}
