namespace Tandelion0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createaccountDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "CreateAccountID", c => c.Int());
            AddColumn("dbo.Tenders", "CreateAccount_ID", c => c.Int());
            CreateIndex("dbo.Tenders", "CreateAccountID");
            CreateIndex("dbo.Tenders", "CreateAccount_ID");
            AddForeignKey("dbo.Tenders", "CreateAccountID", "dbo.CreateAccounts", "ID");
            AddForeignKey("dbo.Tenders", "CreateAccount_ID", "dbo.CreateAccounts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenders", "CreateAccount_ID", "dbo.CreateAccounts");
            DropForeignKey("dbo.Tenders", "CreateAccountID", "dbo.CreateAccounts");
            DropIndex("dbo.Tenders", new[] { "CreateAccount_ID" });
            DropIndex("dbo.Tenders", new[] { "CreateAccountID" });
            DropColumn("dbo.Tenders", "CreateAccount_ID");
            DropColumn("dbo.Tenders", "CreateAccountID");
        }
    }
}
