namespace Tandelion0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAccount_TradeType2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CreateAccounts", name: "Trade_ID", newName: "TradeID");
            RenameIndex(table: "dbo.CreateAccounts", name: "IX_Trade_ID", newName: "IX_TradeID");
            DropColumn("dbo.CreateAccounts", "TradeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreateAccounts", "TradeType", c => c.String());
            RenameIndex(table: "dbo.CreateAccounts", name: "IX_TradeID", newName: "IX_Trade_ID");
            RenameColumn(table: "dbo.CreateAccounts", name: "TradeID", newName: "Trade_ID");
        }
    }
}
