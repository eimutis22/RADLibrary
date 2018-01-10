namespace RADLibrary.Migrations.ApplicationMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RADLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RADLibrary.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationMigrations";
        }

        protected override void Seed(RADLibrary.Models.ApplicationDbContext context)
        {
            var manager =
             new UserManager<ApplicationUser>(
                 new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Librarian" });
            roleManager.Create(new IdentityRole { Name = "Member" });



            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                UserName = "einstein.albert@itsligo.ie",
                Email = "einstein.albert@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$1")
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                UserName = "blogs.joe@itsligo.ie",
                Email = "blogs.joe@itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("ITSligo$2")
            });



            ApplicationUser librarian = manager.FindByEmail("einstein.albert@itsligo.ie");
            if (librarian != null)
            {
                manager.AddToRoles(librarian.Id, new string[] { "Librarian" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }

            ApplicationUser member = manager.FindByEmail("blogs.joe@itsligo.ie");
            if (member != null)
            {
                manager.AddToRoles(member.Id, new string[] { "Member" });
            }
            else
            {
                throw new Exception { Source = "Did not find user" };
            }
        }
    }
}
