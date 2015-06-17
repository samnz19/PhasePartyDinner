namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmenuitemmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("aroy.MenuItems", "IsDeleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("aroy.MenuItems", "IsDeleted");
        }
    }
}
