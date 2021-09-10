using Ardalis.GuardClauses;
using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel;
using Media.Api.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Media.Api.Core.AuthorAggregate
{
    public class Author : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Book> Books { get; set; }

        public Author()
        {

        }
        public Author(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);

            this.Books = new List<Book>();
        }

        public void SetFirstName(string firstName)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        }

        public void SetLastName(string lastName)
        {
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        }
    }
}
