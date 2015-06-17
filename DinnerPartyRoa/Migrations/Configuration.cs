using System.Collections.Generic;
using System.Security.Cryptography;
using DinnerPartyRoa.Models;

namespace DinnerPartyRoa.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DinnerPartyRoa.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DinnerPartyRoa.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.MenuItems.AddOrUpdate(
            //  p => p.Title,
            //  new MenuItem[] { Title = "Andrew Peters" },
            //  new MenuItem() { FullName = "Brice Lambson" },
            //  new MenuItem() { FullName = "Rowan Miller" }
            //);
            //var image = new ImageModel();


            //context.MenuItems.AddOrUpdate(
            //    x => x.Title,
            //    new MenuItem(){ Title = "Pad Thai" },
            //    new MenuItem() { Title = "Ginger Chicken"},
            //    new MenuItem() { Title = "Plum Duck"},
            //    new MenuItem() { Title = "Steamed Chiken Rice" },
            //    new MenuItem() { Title = "Green Curry"},
            //    new MenuItem() { Title = "Chili Chicken"},
            //    new MenuItem() { Title = "Wonton Soup with BBQ Pork"}



            //    //new MenuItem() { Title = "Pad Thai", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/20111103padthai.jpg")},
            //    //new MenuItem() { Title = "Ginger Chicken", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/GingerChicken.jpg") },
            //    //new MenuItem() { Title = "Plum Duck", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/PlumDuck.jpg") },
            //    //new MenuItem() { Title = "Steamed Chiken Rice", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/SteamedChicken.jpg") },
            //    //new MenuItem() { Title = "Green Curry", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/GreenCurry.jpg") },
            //    //new MenuItem() { Title = "Chili Chicken", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/ChiliChicken.jpg") },
            //    //new MenuItem() { Title = "Wonton Soup with BBQ Pork", Image = image.ImageToByteArray("C:/Users/user/Documents/GitHub/PhasePartyDinner/DinnerPartyRoa/Content/Img/Wonton.jpg")}
            //    );

            //context.GitHubUsers.AddOrUpdate(
            //    u => u.Name,
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() },
            //    new GitHubUser() { Name = Faker.NameFaker.Name() }
            //    );
            //context.SaveChanges();


            //GitHubUser user1 = context.GitHubUsers.Find(1);
            //GitHubUser user2 = context.GitHubUsers.Find(2);
            //GitHubUser user3 = context.GitHubUsers.Find(3);

            //MenuItem item1 = context.MenuItems.Find(1);
            //MenuItem item2 = context.MenuItems.Find(2);
            //MenuItem item3 = context.MenuItems.Find(3);



            //context.Orders.AddRange(
            //    new List<Order>(){
            //    new Order() { Item = item1, User = user1, CreatedOn = DateTime.Now},
            //    new Order() { Item = item1, User = user2, CreatedOn = DateTime.Now},
            //    new Order() { Item = item2, User = user2, CreatedOn = DateTime.Now},
            //    new Order() { Item = item3, User = user1, CreatedOn = DateTime.Now},
            //    new Order() { Item = item3, User = user3, CreatedOn = DateTime.Now}
            //    }
            //);

        }
    }
}
