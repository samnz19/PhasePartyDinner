namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namespaceTables : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.MenuItems", newSchema: "aroy");
            MoveTable(name: "dbo.PersonPlacingOrders", newSchema: "aroy");
            MoveTable(name: "dbo.AspNetRoles", newSchema: "aroy");
            MoveTable(name: "dbo.AspNetUserRoles", newSchema: "aroy");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "aroy");
            MoveTable(name: "dbo.AspNetUserClaims", newSchema: "aroy");
            MoveTable(name: "dbo.AspNetUserLogins", newSchema: "aroy");
        }
        
        public override void Down()
        {
            MoveTable(name: "aroy.AspNetUserLogins", newSchema: "dbo");
            MoveTable(name: "aroy.AspNetUserClaims", newSchema: "dbo");
            MoveTable(name: "aroy.AspNetUsers", newSchema: "dbo");
            MoveTable(name: "aroy.AspNetUserRoles", newSchema: "dbo");
            MoveTable(name: "aroy.AspNetRoles", newSchema: "dbo");
            MoveTable(name: "aroy.PersonPlacingOrders", newSchema: "dbo");
            MoveTable(name: "aroy.MenuItems", newSchema: "dbo");
        }
    }
}
