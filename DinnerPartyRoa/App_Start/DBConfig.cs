using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using DinnerPartyRoa.Models;
using DinnerPartyRoa.Migrations;

namespace DinnerPartyRoa.App_Start
{
    public  static class DBConfig
    {
        public static void RunDbMigrations()
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            using (var context = new ApplicationDbContext())
            {
                context.Database.Initialize(false);
            }
        }
    }
}