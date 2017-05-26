namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GalleryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGalleryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
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
            DropForeignKey("dbo.PhotoModels", "UserGalleryModel_Id", "dbo.UserGalleryModels");
            DropForeignKey("dbo.UserGalleryModels", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PhotoModels", new[] { "UserGalleryModel_Id" });
            DropIndex("dbo.UserGalleryModels", new[] { "Owner_Id" });
            DropTable("dbo.PhotoModels");
            DropTable("dbo.UserGalleryModels");
        }
    }
}
