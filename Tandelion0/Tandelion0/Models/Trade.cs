using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class Trade
    {
        public int ID { get; set; }
        public string TradeType { get; set; }
        //TradeTypr can be selected from CreateAccount
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Progress { get; set; }
        public int? TendererNo { get; set; }
        //refer from Tenderer 
        public int? ProjectID { get; set; }
        public int? CreateAccountID { get; set; }
        //refer from Project

        //public string projectName { get; set; } **
        //interface
        public virtual Project Project { get; set; }
        //public virtual CreateAccount CreateAccount { get; set; }
        public virtual ICollection<CreateAccount> CreateAccount { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
        
    }
}