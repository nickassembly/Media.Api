using Ardalis.GuardClauses;
using Media.Api.SharedKernel;
using Media.Api.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Core.BookAggregate
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Isbn { get; private set; }
        public string Isbn13 { get; private set; }
        public List<string> Authors { get; private set; }
        public string Title { get; private set; }
        public MediaType MediaType { get; private set; }
        public string Publisher { get; private set; }
        public DateTimeOffset PublishDate { get; private set; }
        public decimal ListPrice { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid UpdatedBy { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }

        public Book(string isbn, string isbn13, List<string> authors, string title, MediaType mediaType,
            string publisher, DateTimeOffset publishDate, decimal listPrice,
            Guid createdBy, Guid updatedBy, DateTimeOffset createdDate, DateTimeOffset updatedDate)
        {
            SetIsbn(isbn);
        }

        private void SetIsbn(string isbn)
        {
            Isbn = Guard.Against.NullOrEmpty(isbn, nameof(isbn));

        }

        // TODO: Add the rest of the Set methods

    }
}
