using EFCore5WebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace EFCore5WebApp.DAL.Tests
{
    public abstract class AppDbContextTestsBase
    {
        protected AppDbContext _context;

        [SetUp]
        public virtual void Setup()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=EFCore5WebApp;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options);
        }

        protected Person CreateClarkKent()
        {
            return new Person
            {
                FirstName = "Clark",
                LastName = "Kent",
                EmailAddress = "clark@dailybugle.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = "1234 Fake Street",
                        AddressLine2 = "Suite 1",
                        City = "Chicago",
                        State = "IL",
                        ZipCode = "60652",
                        Country = "United States"
                    }
                }
            };

        }
    }
}
