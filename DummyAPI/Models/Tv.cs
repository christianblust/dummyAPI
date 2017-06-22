using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DummyAPI.Models
{
    public class Tv
    {
        public  string Channel { get; set; }
        public  string Volume { get; set; }
        public  bool Status { get; set; }

       public Tv(string channel, string volume, bool status)
        {
            Channel = channel;
            Volume = volume;
            Status = status;
        }
    }
}

