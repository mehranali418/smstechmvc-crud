using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSTech.Models
{
    public class Closings
    {
        public string Desc { get; set; }
        public string CDate { get; set; }
        public string CMonth { get; set; }
        public int CTotalFess { get; set; }
        public string CTotalAmount { get; set; }
        public string CProfit { get; set; }
    }
}