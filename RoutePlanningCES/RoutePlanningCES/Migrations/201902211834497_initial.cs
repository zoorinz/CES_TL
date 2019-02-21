namespace RoutePlanningCES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dimension",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        width = c.Single(nullable: false),
                        height = c.Single(nullable: false),
                        length = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Edge",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Duration = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        MaxWeight = c.Single(nullable: false),
                        Company_ID = c.Int(),
                        DestinationCity_ID = c.Int(),
                        SourceCity_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.Company_ID)
                .ForeignKey("dbo.City", t => t.DestinationCity_ID)
                .ForeignKey("dbo.City", t => t.SourceCity_ID)
                .Index(t => t.Company_ID)
                .Index(t => t.DestinationCity_ID)
                .Index(t => t.SourceCity_ID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Parcel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationCity_ID = c.Int(),
                        Dimensions_ID = c.Int(),
                        Reciver_ID = c.Int(),
                        Sender_ID = c.Int(),
                        SourceCity_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.DestinationCity_ID)
                .ForeignKey("dbo.Dimension", t => t.Dimensions_ID)
                .ForeignKey("dbo.User", t => t.Reciver_ID)
                .ForeignKey("dbo.User", t => t.Sender_ID)
                .ForeignKey("dbo.City", t => t.SourceCity_ID)
                .Index(t => t.DestinationCity_ID)
                .Index(t => t.Dimensions_ID)
                .Index(t => t.Reciver_ID)
                .Index(t => t.Sender_ID)
                .Index(t => t.SourceCity_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        eMail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeEdge",
                c => new
                    {
                        Type_ID = c.Int(nullable: false),
                        Edge_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Type_ID, t.Edge_ID })
                .ForeignKey("dbo.Type", t => t.Type_ID, cascadeDelete: true)
                .ForeignKey("dbo.Edge", t => t.Edge_ID, cascadeDelete: true)
                .Index(t => t.Type_ID)
                .Index(t => t.Edge_ID);
            
            CreateTable(
                "dbo.ParcelType",
                c => new
                    {
                        Parcel_Id = c.Int(nullable: false),
                        Type_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Parcel_Id, t.Type_ID })
                .ForeignKey("dbo.Parcel", t => t.Parcel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Type", t => t.Type_ID, cascadeDelete: true)
                .Index(t => t.Parcel_Id)
                .Index(t => t.Type_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParcelType", "Type_ID", "dbo.Type");
            DropForeignKey("dbo.ParcelType", "Parcel_Id", "dbo.Parcel");
            DropForeignKey("dbo.Parcel", "SourceCity_ID", "dbo.City");
            DropForeignKey("dbo.Parcel", "Sender_ID", "dbo.User");
            DropForeignKey("dbo.Parcel", "Reciver_ID", "dbo.User");
            DropForeignKey("dbo.Parcel", "Dimensions_ID", "dbo.Dimension");
            DropForeignKey("dbo.Parcel", "DestinationCity_ID", "dbo.City");
            DropForeignKey("dbo.TypeEdge", "Edge_ID", "dbo.Edge");
            DropForeignKey("dbo.TypeEdge", "Type_ID", "dbo.Type");
            DropForeignKey("dbo.Edge", "SourceCity_ID", "dbo.City");
            DropForeignKey("dbo.Edge", "DestinationCity_ID", "dbo.City");
            DropForeignKey("dbo.Edge", "Company_ID", "dbo.Company");
            DropIndex("dbo.ParcelType", new[] { "Type_ID" });
            DropIndex("dbo.ParcelType", new[] { "Parcel_Id" });
            DropIndex("dbo.TypeEdge", new[] { "Edge_ID" });
            DropIndex("dbo.TypeEdge", new[] { "Type_ID" });
            DropIndex("dbo.Parcel", new[] { "SourceCity_ID" });
            DropIndex("dbo.Parcel", new[] { "Sender_ID" });
            DropIndex("dbo.Parcel", new[] { "Reciver_ID" });
            DropIndex("dbo.Parcel", new[] { "Dimensions_ID" });
            DropIndex("dbo.Parcel", new[] { "DestinationCity_ID" });
            DropIndex("dbo.Edge", new[] { "SourceCity_ID" });
            DropIndex("dbo.Edge", new[] { "DestinationCity_ID" });
            DropIndex("dbo.Edge", new[] { "Company_ID" });
            DropTable("dbo.ParcelType");
            DropTable("dbo.TypeEdge");
            DropTable("dbo.User");
            DropTable("dbo.Parcel");
            DropTable("dbo.Type");
            DropTable("dbo.Edge");
            DropTable("dbo.Dimension");
            DropTable("dbo.Company");
            DropTable("dbo.City");
        }
    }
}
