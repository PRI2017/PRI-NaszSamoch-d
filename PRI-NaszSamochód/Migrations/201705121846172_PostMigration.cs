namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendModels",
                c => new
                    {
                        User1Id = c.Int(nullable: false, identity: true),
                        User2Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        User1_Id = c.String(maxLength: 128),
                        User2_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.User1Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User1_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User2_Id)
                .Index(t => t.User1_Id)
                .Index(t => t.User2_Id);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PhotoPath = c.String(),
                        Creator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id, cascadeDelete: true)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Creator_Id = c.String(maxLength: 128),
                        PostModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.PostModels", t => t.PostModel_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.PostModel_Id);
            
            CreateTable(
                "dbo.LikeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Liker_Id = c.String(maxLength: 128),
                        PostModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Liker_Id)
                .ForeignKey("dbo.PostModels", t => t.PostModel_Id)
                .Index(t => t.Liker_Id)
                .Index(t => t.PostModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikeModels", "PostModel_Id", "dbo.PostModels");
            DropForeignKey("dbo.LikeModels", "Liker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostModels", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentModels", "PostModel_Id", "dbo.PostModels");
            DropForeignKey("dbo.CommentModels", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendModels", "User2_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendModels", "User1_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LikeModels", new[] { "PostModel_Id" });
            DropIndex("dbo.LikeModels", new[] { "Liker_Id" });
            DropIndex("dbo.CommentModels", new[] { "PostModel_Id" });
            DropIndex("dbo.CommentModels", new[] { "Creator_Id" });
            DropIndex("dbo.PostModels", new[] { "Creator_Id" });
            DropIndex("dbo.FriendModels", new[] { "User2_Id" });
            DropIndex("dbo.FriendModels", new[] { "User1_Id" });
            DropTable("dbo.LikeModels");
            DropTable("dbo.CommentModels");
            DropTable("dbo.PostModels");
            DropTable("dbo.FriendModels");
        }
    }
}
