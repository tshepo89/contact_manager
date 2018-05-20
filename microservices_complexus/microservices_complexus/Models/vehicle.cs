using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace microservices_complexus.Models
{
    public class vehicle
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public double engine_capacity { get; set; }
        public double cylinder_variant { get; set; }
        public int top_speed { get; set; }
        public double price { get; set; }
    }
}