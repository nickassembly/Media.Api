using Media.Api.Core.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Infrastructure.Data.Config.BookAggregate
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // TODO: What other properties will be required in the db
            // add in properties and run migration

            builder.Property(p => p.Isbn)
                .HasMaxLength(10);

            builder.Property(p => p.Isbn13)
                .HasMaxLength(13)
                .IsRequired();

            // TODO: Validate authors in list / list size
            builder.Property(p => p.Authors)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
