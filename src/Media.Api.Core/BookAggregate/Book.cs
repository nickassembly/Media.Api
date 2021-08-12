using Ardalis.GuardClauses;
using Media.Api.Core.AuthorAggregate;
using Media.Api.SharedKernel;
using Media.Api.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Media.Api.Core.BookAggregate
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Isbn { get; private set; }
        public string Isbn13 { get; private set; }
        public List<Author> Authors { get; private set; }
        public string Title { get; private set; }
        public MediaType MediaType { get; private set; }
        public string Publisher { get; private set; }
        public DateTimeOffset PublishDate { get; private set; }
        public decimal ListPrice { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid UpdatedBy { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }

        public Book()
        {

        }

        public Book(string isbn, string isbn13, string title, MediaType mediaType,
            string publisher, DateTimeOffset publishDate, decimal listPrice,
            Guid createdBy, Guid updatedBy, DateTimeOffset createdDate, DateTimeOffset updatedDate)
        {
            SetIsbn(isbn);
            SetIsbn13(isbn13);
            SetTitle(title);
            SetMediaType(mediaType);
            SetPublisher(publisher);
            SetPublishDate(publishDate);
            SetListPrice(listPrice);
            SetCreatedBy(createdBy);
            SetCreatedDate(createdDate);
            SetUpdatedBy(updatedBy);
            SetUpdatedDate(updatedDate);

            this.Authors = new List<Author>();
        }

        public void SetIsbn(string isbn)
        {
            // TODO: Method to take out dashes so isbn only stores numbers
            Isbn = Guard.Against.NullOrEmpty(isbn, nameof(isbn));
        }
        public void SetIsbn13(string isbn13)
        {
            Isbn13 = Guard.Against.NullOrEmpty(isbn13, nameof(isbn13));
        }

        public void SetTitle(string title) => Title = Guard.Against.NullOrEmpty(title, nameof(title));
        public void SetMediaType(MediaType mediaType)
        {
            MediaType = Guard.Against.InvalidInput(mediaType, nameof(mediaType), mt => Enum.IsDefined(mediaType));
        }

        public void SetPublisher(string publisher) => Publisher = Guard.Against.NullOrEmpty(publisher, nameof(publisher));
        public void SetPublishDate(DateTimeOffset publishDate) => Guard.Against.Null(publishDate, nameof(publishDate));
        public void SetListPrice(decimal listPrice) => Guard.Against.Null(listPrice, nameof(listPrice));
        public void SetCreatedBy(Guid createdBy) => Guard.Against.Null(createdBy, nameof(createdBy));
        public void SetUpdatedBy(Guid updatedBy) => Guard.Against.Null(updatedBy, nameof(updatedBy));
        public void SetCreatedDate(DateTimeOffset createdDate) => Guard.Against.Null(createdDate, nameof(createdDate));
        public void SetUpdatedDate(DateTimeOffset updatedDate) => Guard.Against.Null(updatedDate, nameof(updatedDate));

    }
}
