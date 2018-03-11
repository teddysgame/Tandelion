using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class CreateAccount
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string PICName { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        //public string TradeType { get; set; }
        public decimal? PICContactNo { get; set; }
        public decimal CompanyContactNo { get; set; }
        public decimal? FaxNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public int? Rating { get; set; }
        public int? Frequency { get; set; }
        public int? TradeID { get; set; }
        public int? TenderID { get; set; }
        //public virtual Project Project { get; set; }
        //public virtual Trade Trade { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
        public virtual Trade Trade { get; set; }
        //bind data to Tender

    }
}