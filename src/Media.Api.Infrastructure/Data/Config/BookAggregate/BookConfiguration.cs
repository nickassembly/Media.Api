using Media.Api.Core.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media.Api.Infrastructure.Data.Config.BookAggregate
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Isbn)
                .HasMaxLength(10);

            builder.Property(p => p.Isbn13)
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
