namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftergroupsmerge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RouteModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_Id = c.String(maxLength: 128),
                        Statistics_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.RouteStatisticsModels", t => t.Statistics_Key)
                .Index(t => t.Owner_Id)
                .Index(t => t.Statistics_Key);
            
            CreateTable(
                "dbo.POIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RouteModel_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RouteModels", t => t.RouteModel_Key)
                .Index(t => t.RouteModel_Key);
            
            CreateTable(
                "dbo.RouteStatisticsModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        RouteLength = c.Double(nullable: false),
                        RouteStartTime = c.DateTime(nullable: false),
                        RouteEndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        YearBuilt = c.String(),
                        YearBought = c.String(),
                        Color = c.String(),
                        VehicleBody = c.Int(nullable: false),
                        Engine_Key = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.EngineModels", t => t.Engine_Key)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Engine_Key)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.EngineModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        EngineSpeed = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                        EngineType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.VehicleStatisticsModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        KilometersDriven = c.Double(nullable: false),
                        FuelUsed = c.Double(nullable: false),
                        MaxVelocity = c.Double(nullable: false),
                        RecordTime = c.DateTime(nullable: false),
                        VehicleModel_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModel_Key)
                .Index(t => t.VehicleModel_Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleStatisticsModels", "VehicleModel_Key", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleModels", "Engine_Key", "dbo.EngineModels");
            DropForeignKey("dbo.RouteModels", "Statistics_Key", "dbo.RouteStatisticsModels");
            DropForeignKey("dbo.POIs", "RouteModel_Key", "dbo.RouteModels");
            DropForeignKey("dbo.RouteModels", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleStatisticsModels", new[] { "VehicleModel_Key" });
            DropIndex("dbo.VehicleModels", new[] { "Owner_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Engine_Key" });
            DropIndex("dbo.POIs", new[] { "RouteModel_Key" });
            DropIndex("dbo.RouteModels", new[] { "Statistics_Key" });
            DropIndex("dbo.RouteModels", new[] { "Owner_Id" });
            DropTable("dbo.VehicleStatisticsModels");
            DropTable("dbo.EngineModels");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.RouteStatisticsModels");
            DropTable("dbo.POIs");
            DropTable("dbo.RouteModels");
        }
    }
}
