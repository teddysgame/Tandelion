using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class Tender
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        //CompanyName refer from CreateAccount or CreateTender 
        //bind PICName, PICContactNo, Designation, CompanyContactNo
        public List<CreateAccount> FrequentCompanyName { get; set; }
        public List<CreateAccount> SuggestCompanyName { get; set; }
        public List<CreateAccount> SelectedCompanyName { get; set; }
        public List<CreateAccount> AllCompanyName { get; set; }
        public string Status { get; set; }
        public string PICName { get; set; }
        //PICName refer from CreateAccount
        public Decimal PICContactNo { get; set; }
        //PICContactNo refer from CreateAccount
        public string Designation { get; set; }
        //Designation refer from CreateAccount
        public Decimal CompanyContactNo { get; set; }
        //CompanyContactNo refer from CreateAccount
        
        public int? ProjectID { get; set; }
        public int? TradeID { get; set; }
        public int? CreateAccountID { get; set; }
        public virtual Trade Trade { get; set; }
        //to import TradeType from Trade 
        //public virtual CreateAccount CreateAccount { get; set; }
        public virtual Project Project { get; set; }
        //to import ProjectName from Project
        //public ICollection<Invitation> Invitation { get; set; }
        public virtual CreateAccount CreateAccount { get; set; }

    }
}