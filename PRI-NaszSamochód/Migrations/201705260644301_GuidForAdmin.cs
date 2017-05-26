namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidForAdmin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels");
            DropPrimaryKey("dbo.AdministratorModels");
            AlterColumn("dbo.AdministratorModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AdministratorModels", "Id");
            AddForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels");
            DropPrimaryKey("dbo.AdministratorModels");
            AlterColumn("dbo.AdministratorModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AdministratorModels", "Id");
            AddForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels", "Id");
        }
    }
}
