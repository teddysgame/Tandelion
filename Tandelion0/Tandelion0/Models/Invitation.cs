using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class Invitation
    {
        public int ID { get; set; }
        public int Message { get; set; }
        //public string ProjectName { get; set; }
        //public string ProjectTitle { get; set; }
        public int? TenderID { get; set; }
        public int? ProjectID { get; set; }
        public virtual Tender Tender { get; set; }
        public virtual Project Project { get; set; }
    }
}