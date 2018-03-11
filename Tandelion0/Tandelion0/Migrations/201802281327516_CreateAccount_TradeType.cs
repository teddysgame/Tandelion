namespace Tandelion0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAccount_TradeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreateAccounts", "TradeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreateAccounts", "TradeType");
        }
    }
}
