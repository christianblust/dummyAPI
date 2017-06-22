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
        public  string Status { get; set; }

       public Tv(string channel, string volume, string status)
        {
            Channel = channel;
            Volume = volume;
            Status = status;
        }
    }
}

