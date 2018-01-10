namespace RADLibrary.Migrations.LibraryMigrations
{
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Rad301ChristmasExam2017.Models;
    using RADLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rad301ChristmasExam2017.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\LibraryMigrations";
        }

        protected override void Seed(Rad301ChristmasExam2017.Models.LibraryContext context)
        {
            SeedMembers(context);
            SeedBooks(context);
        }

        private void SeedMembers(LibraryContext context)
        {
            context.Members.AddOrUpdate(u => u.MemberID, new Rad301ChristmasExam2017.Models.Member
            {
                FirstName = "John",
                SecondName = "Smith",
                DateJoined = DateTime.Now
            });

            context.Members.AddOrUpdate(u => u.MemberID, new Rad301ChristmasExam2017.Models.Member
            {
                FirstName = "Jimmy",
                SecondName = "Johnson",
                DateJoined = DateTime.Now
            });
        }

        private void SeedBooks(LibraryContext context)
        {
            context.Books.AddOrUpdate(u => u.BookID, new Book
            {
                Author = "Phil Knight",
                ISBN = "123456",
                Title = "Shoe Dog"
            });

            context.Books.AddOrUpdate(u => u.BookID, new Book
            {
                Author = "James Smith",
                ISBN = "123432",
                Title = "Titanic"
            });

            context.Books.AddOrUpdate(u => u.BookID, new Book
            {
                Author = "Jack Bloggs",
                ISBN = "123333",
                Title = "Awesome Book"
            });
        }
    }
}
