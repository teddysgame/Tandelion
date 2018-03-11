namespace Tandelion0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAccount_TradeType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreateAccounts", "TenderID", c => c.Int());
            AddColumn("dbo.CreateAccounts", "Trade_ID", c => c.Int());
            AddColumn("dbo.Trades", "CreateAccountID", c => c.Int());
            CreateIndex("dbo.CreateAccounts", "Trade_ID");
            AddForeignKey("dbo.CreateAccounts", "Trade_ID", "dbo.Trades", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreateAccounts", "Trade_ID", "dbo.Trades");
            DropIndex("dbo.CreateAccounts", new[] { "Trade_ID" });
            DropColumn("dbo.Trades", "CreateAccountID");
            DropColumn("dbo.CreateAccounts", "Trade_ID");
            DropColumn("dbo.CreateAccounts", "TenderID");
        }
    }
}
