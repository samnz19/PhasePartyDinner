namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOn_AddedTo_Orders : DbMigration
    {
        public override void Up()
        {
            AddColumn("aroy.Orders", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("aroy.Orders", "CreatedOn");
        }
    }
}
