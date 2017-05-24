namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaftergroups2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "Engine_Key", "dbo.EngineModels");
            DropForeignKey("dbo.CarModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CarModels", "Statistics_Key", "dbo.VehicleStatisticsModels");
            DropForeignKey("dbo.MotorcycleModels", "Engine_Key", "dbo.EngineModels");
            DropForeignKey("dbo.MotorcycleModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MotorcycleModels", "Statistics_Key", "dbo.VehicleStatisticsModels");
            DropForeignKey("dbo.RouteStatisticsModels", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CarModels", new[] { "Engine_Key" });
            DropIndex("dbo.CarModels", new[] { "Owner_Id" });
            DropIndex("dbo.CarModels", new[] { "Statistics_Key" });
            DropIndex("dbo.MotorcycleModels", new[] { "Engine_Key" });
            DropIndex("dbo.MotorcycleModels", new[] { "Owner_Id" });
            DropIndex("dbo.MotorcycleModels", new[] { "Statistics_Key" });
            DropIndex("dbo.RouteStatisticsModels", new[] { "Owner_Id" });
            DropTable("dbo.CarModels");
            DropTable("dbo.EngineModels");
            DropTable("dbo.VehicleStatisticsModels");
            DropTable("dbo.MotorcycleModels");
            DropTable("dbo.RouteStatisticsModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RouteStatisticsModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        RouteLength = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.MotorcycleModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        YearBuilt = c.String(),
                        YearBought = c.String(),
                        Color = c.String(),
                        Engine_Key = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                        Statistics_Key = c.Int(),
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
                        RecordStartTime = c.DateTime(nullable: false),
                        RecordEndTime = c.DateTime(nullable: false),
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
                "dbo.CarModels",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        CarBody = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        YearBuilt = c.String(),
                        YearBought = c.String(),
                        Color = c.String(),
                        Engine_Key = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                        Statistics_Key = c.Int(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateIndex("dbo.RouteStatisticsModels", "Owner_Id");
            CreateIndex("dbo.MotorcycleModels", "Statistics_Key");
            CreateIndex("dbo.MotorcycleModels", "Owner_Id");
            CreateIndex("dbo.MotorcycleModels", "Engine_Key");
            CreateIndex("dbo.CarModels", "Statistics_Key");
            CreateIndex("dbo.CarModels", "Owner_Id");
            CreateIndex("dbo.CarModels", "Engine_Key");
            AddForeignKey("dbo.RouteStatisticsModels", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MotorcycleModels", "Statistics_Key", "dbo.VehicleStatisticsModels", "Key");
            AddForeignKey("dbo.MotorcycleModels", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MotorcycleModels", "Engine_Key", "dbo.EngineModels", "Key");
            AddForeignKey("dbo.CarModels", "Statistics_Key", "dbo.VehicleStatisticsModels", "Key");
            AddForeignKey("dbo.CarModels", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CarModels", "Engine_Key", "dbo.EngineModels", "Key");
        }
    }
}
