namespace Tandelion0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.Int(nullable: false),
                        TenderID = c.Int(),
                        ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Tenders", t => t.TenderID)
                .Index(t => t.TenderID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectTitle = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Timeline = c.Int(nullable: false),
                        client = c.String(),
                        NoTrade = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TradeType = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Progress = c.Int(nullable: false),
                        TendererNo = c.Int(),
                        ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Status = c.String(),
                        PICName = c.String(),
                        PICContactNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Designation = c.String(),
                        CompanyContactNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProjectID = c.Int(),
                        TradeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Trades", t => t.TradeID)
                .Index(t => t.ProjectID)
                .Index(t => t.TradeID);
            
            CreateTable(
                "dbo.CreateAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        PICName = c.String(),
                        Address = c.String(),
                        Designation = c.String(),
                        PICContactNo = c.Decimal(precision: 18, scale: 2),
                        CompanyContactNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaxNo = c.Decimal(precision: 18, scale: 2),
                        Email = c.String(),
                        RegistrationNo = c.String(),
                        Rating = c.Int(),
                        Frequency = c.Int(),
                        Tender_ID = c.Int(),
                        Tender_ID1 = c.Int(),
                        Tender_ID2 = c.Int(),
                        Tender_ID3 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenders", t => t.Tender_ID)
                .ForeignKey("dbo.Tenders", t => t.Tender_ID1)
                .ForeignKey("dbo.Tenders", t => t.Tender_ID2)
                .ForeignKey("dbo.Tenders", t => t.Tender_ID3)
                .Index(t => t.Tender_ID)
                .Index(t => t.Tender_ID1)
                .Index(t => t.Tender_ID2)
                .Index(t => t.Tender_ID3);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invitations", "TenderID", "dbo.Tenders");
            DropForeignKey("dbo.Invitations", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Tenders", "TradeID", "dbo.Trades");
            DropForeignKey("dbo.CreateAccounts", "Tender_ID3", "dbo.Tenders");
            DropForeignKey("dbo.CreateAccounts", "Tender_ID2", "dbo.Tenders");
            DropForeignKey("dbo.Tenders", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.CreateAccounts", "Tender_ID1", "dbo.Tenders");
            DropForeignKey("dbo.CreateAccounts", "Tender_ID", "dbo.Tenders");
            DropForeignKey("dbo.Trades", "ProjectID", "dbo.Projects");
            DropIndex("dbo.CreateAccounts", new[] { "Tender_ID3" });
            DropIndex("dbo.CreateAccounts", new[] { "Tender_ID2" });
            DropIndex("dbo.CreateAccounts", new[] { "Tender_ID1" });
            DropIndex("dbo.CreateAccounts", new[] { "Tender_ID" });
            DropIndex("dbo.Tenders", new[] { "TradeID" });
            DropIndex("dbo.Tenders", new[] { "ProjectID" });
            DropIndex("dbo.Trades", new[] { "ProjectID" });
            DropIndex("dbo.Invitations", new[] { "ProjectID" });
            DropIndex("dbo.Invitations", new[] { "TenderID" });
            DropTable("dbo.CreateAccounts");
            DropTable("dbo.Tenders");
            DropTable("dbo.Trades");
            DropTable("dbo.Projects");
            DropTable("dbo.Invitations");
        }
    }
}
