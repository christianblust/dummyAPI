using DummyAPI.Helper;
using DummyAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DummyAPI.Controllers
{
    public class TvController : ApiController
    {
       Tv tv = new Tv(null, null, false);

        MyProperties prop = new MyProperties("test.txt");
        
        // GET: api/Tv
        [HttpGet]
        public bool Get()
        {
            return true;
        }

        // GET: api/Tv/5
        public bool Get(int id)
        {
            //if id=1 turn tv on
            if (id == 1) { return true; }
            //else turn tv off
            else return false;
        }

        // POST: api/Tv
        [HttpPost]
        public IHttpActionResult Post([FromBody]Tv tv)
        {
            System.Threading.Thread.Sleep(5000);
            return Ok(tv);
        }

        // PUT: api/Tv/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tv/5
        public void Delete(int id)
        {
        }
    }
}
