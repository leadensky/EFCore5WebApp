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
    public class NavigationPropertyTests : AppDbContextTestsBase
    {
        private Person _person;

        public override void Setup()
        {
            base.Setup();
            _person = CreateClarkKent();
            _person.Addresses.Add(new Address
            {
                AddressLine1 = "555 Waverly Street",
                AddressLine2 = "APT B2",
                City = "Mt Pleasant",
                State = "MI",
                ZipCode = "48858",
                Country = "USA"
            });

            _context.Persons.Add(_person);
            _context.SaveChanges();
        }

        [Test]
        public void GetAddressesFromPerson()
        {
            Assert.AreEqual(2, _person.Addresses.Count());
        }

        [Test]
        public void GetPersonFromAddresses()
        {
            var address = _person.Addresses.First();
            Assert.IsNotNull(address.Person);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Persons.Remove(_person);
            _context.SaveChanges();
        }
    }
}
