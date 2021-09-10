using Media.Api.Core.AuthorAggregate;
using Media.Api.SharedKernel;
using Media.Api.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Media.Api.Core.BookAggregate
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public List<Author> Authors { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
        public string Publisher { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public decimal ListPrice { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Book()
        {
            this.Authors = new List<Author>();
        }
    }
}
