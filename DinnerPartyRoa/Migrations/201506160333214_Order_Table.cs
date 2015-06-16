namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "aroy.GitHubUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "aroy.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("aroy.MenuItems", t => t.Item_Id)
                .ForeignKey("aroy.GitHubUsers", t => t.User_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("aroy.Orders", "User_Id", "aroy.GitHubUsers");
            DropForeignKey("aroy.Orders", "Item_Id", "aroy.MenuItems");
            DropIndex("aroy.Orders", new[] { "User_Id" });
            DropIndex("aroy.Orders", new[] { "Item_Id" });
            DropTable("aroy.Orders");
            DropTable("aroy.GitHubUsers");
        }
    }
}
