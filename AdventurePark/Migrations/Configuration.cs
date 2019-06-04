namespace AdventurePark.Migrations
{
    using AdventurePark.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdventurePark.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AdventurePark.Models.ApplicationDbContext";
        }

        protected override void Seed(AdventurePark.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Rides.AddOrUpdate(r => r.RideName,
                new Rides
                {
                    RideName = "The Tornado",
                    RideDifficultyLevel = 2
                },
                new Rides
                {
                    RideName = "Lazy River",
                    RideDifficultyLevel = 1
                },
                new Rides
                {
                    RideName = "Ali Baba",
                    RideDifficultyLevel = 3
                },
                new Rides
                {
                    RideName = "Alpine Slide",
                    RideDifficultyLevel = 2
                });
            SeedMemberShip(context);
           
        }

        private void SeedMemberShip(AdventurePark.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admins"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admins" };
                manager.Create(role);
            }
            if (!context.Users.Any(r => r.Email == "admin@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@hotmail.com", Email = "admin@hotmail.com" };
                manager.Create(user, "admin.");
                manager.AddToRole(user.Id, "Admins");
            }
        }
    }
}
