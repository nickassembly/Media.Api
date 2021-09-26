using System;
using System.Collections.Generic;
using System.Linq;
using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using Media.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Media.Api.Web
{
    public static class SeedData
    {
        //public static readonly Core.BookAggregate.Book Book1 = new Core.BookAggregate.Book
        //{
        //    Title = "It"

        //};

        //public static readonly Core.BookAggregate.Book Book2 = new Core.BookAggregate.Book
        //{
        //    Title = "Jurassic Park"
        //};

        //public static readonly Core.BookAggregate.Book Book3 = new Core.BookAggregate.Book
        //{
        //    Title = "Something something Man Month"
        //};

        public static readonly Book Book1 = new Book()
        {
            Title = "The Stand",
            Publisher = "Penguin",
            ListPrice = 9.99m
        };

        public static readonly Book Book2 = new Book()
        {
            Title = "7 Habits",
            Publisher = "McGraw",
            ListPrice = 5.99m
        };

        public static readonly Book Book3 = new Book()
        {
            Title = "It",
            Publisher = "Pearson",
            ListPrice = 6.99m
        };

        public static readonly Book Book4 = new Book()
        {
            Title = "Regulators",
            Publisher = "Random",
            ListPrice = 2.99m
        };

        public static readonly Book Book5 = new Book()
        {
            Title = "What the bleep",
            Publisher = "Harper C",
            ListPrice = 7.99m
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

            if (dbContext.Books.Any())
            {
                return;
            }

            PopulateTestData(dbContext);
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Books)
            {
                dbContext.Remove(item);
            }

            dbContext.SaveChanges();

            try
            {
                var books = new List<Book>
                {
                    Book1,
                    Book2,
                    Book3,
                    Book4,
                    Book5
                };
                dbContext.AddRange(books);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void PopulateAuthorData(AppDbContext dbContext)
        {
            // TODO: Add Author Data
        }
    }
}
