namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbgenkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels");
            DropPrimaryKey("dbo.AdministratorModels");
            DropPrimaryKey("dbo.MembersModels");
            AlterColumn("dbo.AdministratorModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MembersModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AdministratorModels", "Id");
            AddPrimaryKey("dbo.MembersModels", "Id");
            AddForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels");
            DropPrimaryKey("dbo.MembersModels");
            DropPrimaryKey("dbo.AdministratorModels");
            AlterColumn("dbo.MembersModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AdministratorModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MembersModels", "Id");
            AddPrimaryKey("dbo.AdministratorModels", "Id");
            AddForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.AdministratorModels", "Id");
        }
    }
}
