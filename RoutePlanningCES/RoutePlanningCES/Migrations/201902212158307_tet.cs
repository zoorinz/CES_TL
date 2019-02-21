namespace RoutePlanningCES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.City", "Name", c => c.String());
        }
    }
}
