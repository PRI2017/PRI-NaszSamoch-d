namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationV4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RouteModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.POIs", "RouteModel_Key", "dbo.RouteModels");
            DropForeignKey("dbo.RouteModels", "Statistics_Key", "dbo.RouteStatisticsModels");
            DropForeignKey("dbo.VehicleModels", "Engine_Key", "dbo.EngineModels");
            DropForeignKey("dbo.VehicleModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleStatisticsModels", "VehicleModel_Key", "dbo.VehicleModels");
            DropIndex("dbo.RouteModels", new[] { "Owner_Id" });
            DropIndex("dbo.RouteModels", new[] { "Statistics_Key" });
            DropIndex("dbo.POIs", new[] { "RouteModel_Key" });
            DropIndex("dbo.VehicleModels", new[] { "Engine_Key" });
            DropIndex("dbo.VehicleModels", new[] { "Owner_Id" });
            DropIndex("dbo.VehicleStatisticsModels", new[] { "VehicleModel_Key" });
            DropTable("dbo.RouteModels");
            DropTable("dbo.POIs");
            DropTable("dbo.RouteStatisticsModels");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.EngineModels");
            DropTable("dbo.VehicleStatisticsModels");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Key);
            
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
                .PrimaryKey(t => t.Key);
            
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
                "dbo.POIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RouteModel_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RouteModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_Id = c.String(maxLength: 128),
                        Statistics_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateIndex("dbo.VehicleStatisticsModels", "VehicleModel_Key");
            CreateIndex("dbo.VehicleModels", "Owner_Id");
            CreateIndex("dbo.VehicleModels", "Engine_Key");
            CreateIndex("dbo.POIs", "RouteModel_Key");
            CreateIndex("dbo.RouteModels", "Statistics_Key");
            CreateIndex("dbo.RouteModels", "Owner_Id");
            AddForeignKey("dbo.VehicleStatisticsModels", "VehicleModel_Key", "dbo.VehicleModels", "Key");
            AddForeignKey("dbo.VehicleModels", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VehicleModels", "Engine_Key", "dbo.EngineModels", "Key");
            AddForeignKey("dbo.RouteModels", "Statistics_Key", "dbo.RouteStatisticsModels", "Key");
            AddForeignKey("dbo.POIs", "RouteModel_Key", "dbo.RouteModels", "Key");
            AddForeignKey("dbo.RouteModels", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
