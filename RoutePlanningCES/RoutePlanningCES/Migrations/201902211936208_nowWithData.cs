namespace RoutePlanningCES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowWithData : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ParcelType", new[] { "Parcel_Id" });
            RenameColumn(table: "dbo.Parcel", name: "Reciver_ID", newName: "Receiver_ID");
            RenameIndex(table: "dbo.Parcel", name: "IX_Reciver_ID", newName: "IX_Receiver_ID");
            CreateIndex("dbo.ParcelType", "Parcel_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ParcelType", new[] { "Parcel_ID" });
            RenameIndex(table: "dbo.Parcel", name: "IX_Receiver_ID", newName: "IX_Reciver_ID");
            RenameColumn(table: "dbo.Parcel", name: "Receiver_ID", newName: "Reciver_ID");
            CreateIndex("dbo.ParcelType", "Parcel_Id");
        }
    }
}
