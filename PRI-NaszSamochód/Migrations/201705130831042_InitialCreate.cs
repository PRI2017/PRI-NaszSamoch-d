namespace PRI_NaszSamochód.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        GroupModel_Id = c.Int(),
                        GroupModel_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupModels", t => t.GroupModel_Id)
                .ForeignKey("dbo.GroupModels", t => t.GroupModel_Id1)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.GroupModel_Id)
                .Index(t => t.GroupModel_Id1);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.GroupModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        Description = c.String(),
                        GroupTheme = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PhotoPath = c.String(),
                        Creator_Id = c.String(nullable: false, maxLength: 128),
                        GroupModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id, cascadeDelete: true)
                .ForeignKey("dbo.GroupModels", t => t.GroupModel_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.GroupModel_Id);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostModels", "GroupModel_Id", "dbo.GroupModels");
            DropForeignKey("dbo.LikeModels", "PostModel_Id", "dbo.PostModels");
            DropForeignKey("dbo.LikeModels", "Liker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostModels", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentModels", "PostModel_Id", "dbo.PostModels");
            DropForeignKey("dbo.CommentModels", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "GroupModel_Id1", "dbo.GroupModels");
            DropForeignKey("dbo.AspNetUsers", "GroupModel_Id", "dbo.GroupModels");
            DropForeignKey("dbo.FriendModels", "User2_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendModels", "User1_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LikeModels", new[] { "PostModel_Id" });
            DropIndex("dbo.LikeModels", new[] { "Liker_Id" });
            DropIndex("dbo.CommentModels", new[] { "PostModel_Id" });
            DropIndex("dbo.CommentModels", new[] { "Creator_Id" });
            DropIndex("dbo.PostModels", new[] { "GroupModel_Id" });
            DropIndex("dbo.PostModels", new[] { "Creator_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupModel_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupModel_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.FriendModels", new[] { "User2_Id" });
            DropIndex("dbo.FriendModels", new[] { "User1_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LikeModels");
            DropTable("dbo.CommentModels");
            DropTable("dbo.PostModels");
            DropTable("dbo.GroupModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.FriendModels");
        }
    }
}
