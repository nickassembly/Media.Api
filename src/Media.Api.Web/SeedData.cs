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
        public static readonly Core.BookAggregate.Book Book1 = new Core.BookAggregate.Book
        {
            Title = "It"

        };

        public static readonly Core.BookAggregate.Book Book2 = new Core.BookAggregate.Book
        {
            Title = "Jurassic Park"
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
            if (!dbContext.Books.Any())
            {
                PopulateBookData(dbContext);
            }

            if (!dbContext.Authors.Any())
            {
                PopulateAuthorData(dbContext);
            }
        }

        private static void PopulateBookData(AppDbContext dbContext)
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
                    Book2
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
