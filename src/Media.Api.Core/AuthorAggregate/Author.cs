using Ardalis.GuardClauses;
using Media.Api.SharedKernel;
using Media.Api.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Core.AuthorAggregate
{
    public class Author : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Author()
        {

        }
        public Author(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
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
