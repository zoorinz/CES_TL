namespace RoutePlanningCES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class routev2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExposedConnection",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        origin = c.String(),
                        destination = c.String(),
                        Time = c.Int(nullable: false),
                        weight = c.Int(nullable: false),
                        parcelType = c.String(),
                        dimensions_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dimension", t => t.dimensions_ID)
                .Index(t => t.dimensions_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExposedConnection", "dimensions_ID", "dbo.Dimension");
            DropIndex("dbo.ExposedConnection", new[] { "dimensions_ID" });
            DropTable("dbo.ExposedConnection");
        }
    }
}
