namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftergroupModelchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembersModels", "GroupModel_Id", "dbo.GroupModels");
            DropIndex("dbo.MembersModels", new[] { "GroupModel_Id1" });
            DropColumn("dbo.MembersModels", "GroupModel_Id");
            RenameColumn(table: "dbo.MembersModels", name: "GroupModel_Id1", newName: "GroupModel_Id");
            AddColumn("dbo.GroupModels", "Administrator_Id", c => c.Int());
            CreateIndex("dbo.GroupModels", "Administrator_Id");
            AddForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.MembersModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupModels", "Administrator_Id", "dbo.MembersModels");
            DropIndex("dbo.GroupModels", new[] { "Administrator_Id" });
            DropColumn("dbo.GroupModels", "Administrator_Id");
            RenameColumn(table: "dbo.MembersModels", name: "GroupModel_Id", newName: "GroupModel_Id1");
            AddColumn("dbo.MembersModels", "GroupModel_Id", c => c.Int());
            CreateIndex("dbo.MembersModels", "GroupModel_Id1");
            AddForeignKey("dbo.MembersModels", "GroupModel_Id", "dbo.GroupModels", "Id");
        }
    }
}
