using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tandelion0.Models;
using System.Data.Entity;

namespace Tandelion0.DAL
{
    public class StoreContext: DbContext
    {
        public DbSet<Project> projectsDB { get; set; }
        public DbSet<Trade> tradesDB { get; set; }
        public DbSet<Tender> tendersDB { get; set; }
        public DbSet<Invitation> invitationDB { get; set; }
        public DbSet<CreateAccount> createaccountDB { get; set; }
    }
}