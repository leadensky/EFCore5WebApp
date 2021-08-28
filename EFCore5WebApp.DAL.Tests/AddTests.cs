using EFCore5WebApp.Core.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5WebApp.DAL.Tests
{
    [TestFixture]
    public class AddTests :AppDbContextTestsBase
    {
        [TearDown]
        public void TearDown()
        {
            var person = _context.Persons.Single(x => x.FirstName == "Clark" && x.LastName == "Kent");
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
        [Test]
        public void InsertPersonWithAddresses()
        {
            var record = CreateClarkKent();
            record.Addresses.Add(
                new Address
                {
                    AddressLine1 = "555 Waverly Street",
                    AddressLine2 = "APT B2",
                    City = "Mt. Pleasant",
                    State = "MI",
                    ZipCode = "48858",
                    Country = "United States"
                });
            
            _context.Persons.Add(record);
            _context.SaveChanges();

            var addedPerson = _context.Persons.Single(x => x.FirstName == "Clark" && x.LastName == "Kent");

            Assert.Greater(addedPerson.Id, 0);
            for(int i = 0; i < record.Addresses.Count; i++)
            {
                Assert.AreEqual(record.Addresses[i].AddressLine1, addedPerson.Addresses[i].AddressLine1);
            }
        }
    }
}
