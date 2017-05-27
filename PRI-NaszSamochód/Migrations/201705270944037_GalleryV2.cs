namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GalleryV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGalleryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner_Id = c.String(maxLength: 128),
                        Vehicle_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.VehicleModels", t => t.Vehicle_Key)
                .Index(t => t.Owner_Id)
                .Index(t => t.Vehicle_Key);
            
            CreateTable(
                "dbo.PhotoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        path = c.String(),
                        UserGalleryModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGalleryModels", t => t.UserGalleryModel_Id)
                .Index(t => t.UserGalleryModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGalleryModels", "Vehicle_Key", "dbo.VehicleModels");
            DropForeignKey("dbo.PhotoModels", "UserGalleryModel_Id", "dbo.UserGalleryModels");
            DropForeignKey("dbo.UserGalleryModels", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PhotoModels", new[] { "UserGalleryModel_Id" });
            DropIndex("dbo.UserGalleryModels", new[] { "Vehicle_Key" });
            DropIndex("dbo.UserGalleryModels", new[] { "Owner_Id" });
            DropTable("dbo.PhotoModels");
            DropTable("dbo.UserGalleryModels");
        }
    }
}
