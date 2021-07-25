using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media.Api.Infrastructure.Data.Config.AuthorAggregate
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.LastName)
                 .HasMaxLength(100)
                 .IsRequired();
        }
    }
}
