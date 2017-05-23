namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaftergroups : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.EngineModels", t => t.Engine_Key)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.VehicleStatisticsModels", t => t.Statistics_Key)
                .Index(t => t.Engine_Key)
                .Index(t => t.Owner_Id)
                .Index(t => t.Statistics_Key);
            
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
                        RecordStartTime = c.DateTime(nullable: false),
                        RecordEndTime = c.DateTime(nullable: false),
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
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.EngineModels", t => t.Engine_Key)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.VehicleStatisticsModels", t => t.Statistics_Key)
                .Index(t => t.Engine_Key)
                .Index(t => t.Owner_Id)
                .Index(t => t.Statistics_Key);
            
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
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteStatisticsModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MotorcycleModels", "Statistics_Key", "dbo.VehicleStatisticsModels");
            DropForeignKey("dbo.MotorcycleModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MotorcycleModels", "Engine_Key", "dbo.EngineModels");
            DropForeignKey("dbo.CarModels", "Statistics_Key", "dbo.VehicleStatisticsModels");
            DropForeignKey("dbo.CarModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CarModels", "Engine_Key", "dbo.EngineModels");
            DropIndex("dbo.RouteStatisticsModels", new[] { "Owner_Id" });
            DropIndex("dbo.MotorcycleModels", new[] { "Statistics_Key" });
            DropIndex("dbo.MotorcycleModels", new[] { "Owner_Id" });
            DropIndex("dbo.MotorcycleModels", new[] { "Engine_Key" });
            DropIndex("dbo.CarModels", new[] { "Statistics_Key" });
            DropIndex("dbo.CarModels", new[] { "Owner_Id" });
            DropIndex("dbo.CarModels", new[] { "Engine_Key" });
            DropTable("dbo.RouteStatisticsModels");
            DropTable("dbo.MotorcycleModels");
            DropTable("dbo.VehicleStatisticsModels");
            DropTable("dbo.EngineModels");
            DropTable("dbo.CarModels");
        }
    }
}
