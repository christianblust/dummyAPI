﻿using DummyAPI.Helper;
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
        MyProperties prop = new MyProperties(System.Web.HttpContext.Current.Server.MapPath("~") + "test.txt");
       
        // GET: api/Tv
        [HttpGet]
        public string Get()
        {
            IEnumerable<KeyValuePair<string, string>> querypara;
            querypara = Request.GetQueryNameValuePairs();

            string result = "";
            string para = querypara.ElementAt(0).Value;

            string status = prop.get("status");

            if (para == "1")
            {
                if (status == "true") result = "TV is already running";
                else
                {
                    prop.set("status", "true");
                    prop.Save();
                    result = "TV is now running";
                }
            }

            if (para == "0")
            {
                if (status == "false") result = "TV is already off";
                else
                {
                    prop.set("status", "false");
                    prop.Save();
                    result = "TV is now off";
                }
            }

            return result;
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
            string status = prop.get("status");
            string response = "";

            if (status == "false")
            {
                response = "TV must be turned on to change the volume or channel!";
                return Ok(response);
            }
           
            // Simulate Timeout for Cortana (check async call timeout)
           //System.Threading.Thread.Sleep(17000);
            
            // set Channel if its not null
            if (tv.Channel != null && tv.Volume != null)
            {
                response = "Channel set to " + tv.Channel + " and volume set to " + tv.Volume;

                prop.set("volume", tv.Volume);
                prop.set("channel", tv.Channel);
                prop.Save();
            }

            // set volume if its not null
            else if (tv.Volume != null && tv.Channel == null)
            {
                response = "Volume set to " + tv.Volume;

                prop.set("volume", tv.Volume);
                prop.Save();
            }

            else if (tv.Channel != null && tv.Volume == null)
            {
                response = "Channel set to " + tv.Channel;

                prop.set("channel", tv.Channel);
                prop.Save();
            }

            return Ok(response);
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
