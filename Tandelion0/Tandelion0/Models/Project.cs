using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tandelion0.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Timeline { get; set; }
        public string client { get; set; }
        public int? NoTrade { get; set; }
        //public virtual CreateAccount CreateAccount { get; set; }
        public virtual ICollection<Trade> Trade { get; set; }
        
    }
}