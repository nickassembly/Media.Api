using System;
using System.Linq;
using Media.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Media.Api.Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
            PopulateTestData(dbContext);
        }

        // TODO: Either fix code below and create a seed data class for test data,
        // or remove once some other testing solution is in place
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
            //var data = BookData.ListTestNewsReleases();

            //dbContext.Books.AddRange(data);

            //dbContext.SaveChanges();
        }

        public static void PopulateAuthorData(AppDbContext dbContext)
        {
            //var data = AuthorData.ListTestEvents();

            //dbContext.Authors.AddRange(data);

            //dbContext.SaveChanges();
        }
    }
}
