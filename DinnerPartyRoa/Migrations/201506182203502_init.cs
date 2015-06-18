namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "aroy.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.Binary(),
                        IsDeleted = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "aroy.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("aroy.MenuItems", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "aroy.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "aroy.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("aroy.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("aroy.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "aroy.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "aroy.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("aroy.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "aroy.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("aroy.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("aroy.AspNetUserRoles", "UserId", "aroy.AspNetUsers");
            DropForeignKey("aroy.AspNetUserLogins", "UserId", "aroy.AspNetUsers");
            DropForeignKey("aroy.AspNetUserClaims", "UserId", "aroy.AspNetUsers");
            DropForeignKey("aroy.AspNetUserRoles", "RoleId", "aroy.AspNetRoles");
            DropForeignKey("aroy.Orders", "Item_Id", "aroy.MenuItems");
            DropIndex("aroy.AspNetUserLogins", new[] { "UserId" });
            DropIndex("aroy.AspNetUserClaims", new[] { "UserId" });
            DropIndex("aroy.AspNetUsers", "UserNameIndex");
            DropIndex("aroy.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("aroy.AspNetUserRoles", new[] { "UserId" });
            DropIndex("aroy.AspNetRoles", "RoleNameIndex");
            DropIndex("aroy.Orders", new[] { "Item_Id" });
            DropTable("aroy.AspNetUserLogins");
            DropTable("aroy.AspNetUserClaims");
            DropTable("aroy.AspNetUsers");
            DropTable("aroy.AspNetUserRoles");
            DropTable("aroy.AspNetRoles");
            DropTable("aroy.Orders");
            DropTable("aroy.MenuItems");
        }
    }
}
