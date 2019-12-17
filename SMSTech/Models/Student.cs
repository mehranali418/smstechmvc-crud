using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSTech.Models
{
    public class Student
    {
        
        public int secid { get; set; }
        public int uid { get; set; }
        public string rollNo { get; set; }
        public string name { get; set; }
        public string sDate { get; set; }
        public int status { get; set; }
        public string image { get; set; }
        public string DOB { get; set; }
        public string sNIC { get; set; }
        public int famid { get; set; }
        public int gender { get; set; }
        public int Cid { get; set; }
        public string leaveDate { get; set; }
        public string regNo { get; set; }
        public int NatId { get; set; }
        public int relId { get; set; }
        public string email { get; set; }
        public int StuGrpId { get; set; }        
    }



    
}