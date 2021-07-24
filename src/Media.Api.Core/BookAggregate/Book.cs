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
            SetIsbn13(isbn13);
            SetTitle(title);
            SetMediaType(mediaType);
            SetAuthors(authors);
            SetPublisher(publisher);
            SetPublishDate(publishDate);
            SetListPrice(listPrice);
            SetCreatedBy(createdBy);
            SetCreatedDate(createdDate);
            SetUpdatedBy(updatedBy);
            SetUpdatedDate(updatedDate);
        }

        private void SetIsbn(string isbn)
        {
            // TODO: Method to take out dashes so isbn only stores numbers
            Isbn = Guard.Against.NullOrEmpty(isbn, nameof(isbn));
        }
        private void SetIsbn13(string isbn13)
        {
            Isbn13 = Guard.Against.NullOrEmpty(isbn13, nameof(isbn13));
        }

        // TODO: how to guard against empty lists
        private void SetAuthors(List<string> authors)
        {
            Authors.AddRange(authors);
        }
        private void SetTitle(string title) => Title = Guard.Against.NullOrEmpty(title, nameof(title));
        private void SetMediaType(MediaType mediaType)
        {
            MediaType = Guard.Against.InvalidInput(mediaType, nameof(mediaType), mt => Enum.IsDefined(mediaType));
        }

        private void SetPublisher(string publisher) => Publisher = Guard.Against.NullOrEmpty(publisher, nameof(publisher));

        private void SetPublishDate(DateTimeOffset publishDate) => Guard.Against.Null(publishDate, nameof(publishDate));
        private void SetListPrice(decimal listPrice) => Guard.Against.Null(listPrice, nameof(listPrice));
        private void SetCreatedBy(Guid createdBy) => Guard.Against.Null(createdBy, nameof(createdBy));
        private void SetUpdatedBy(Guid updatedBy) => Guard.Against.Null(updatedBy, nameof(updatedBy));
        private void SetCreatedDate(DateTimeOffset createdDate) => Guard.Against.Null(createdDate, nameof(createdDate));
        private void SetUpdatedDate(DateTimeOffset updatedDate) => Guard.Against.Null(updatedDate, nameof(updatedDate));

    }
}
