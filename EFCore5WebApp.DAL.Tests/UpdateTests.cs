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
    public class UpdateTests : AppDbContextTestsBase
    {
        private int _personId;

        public override void Setup()
        {
            base.Setup();
            var record = CreateClarkKent();
            _context.Persons.Add(record);
            _context.SaveChanges();
            _personId = record.Id;

        }

        [Test]
        public void UpdatePersonWithAddress()
        {
            var person = _context.Persons.Single(x => x.Id == _personId);
            person.FirstName = "Matt";
            person.LastName = "Smith";
            person.Addresses.First().AddressLine1 = "123 Update St";

            _context.SaveChanges();
            var updatedPerson = _context.Persons.Single(x => x.Id == _personId);
            Assert.AreEqual(1, updatedPerson.Addresses.Count);
            Assert.AreEqual(person.FirstName, updatedPerson.FirstName);
        }

        [TearDown]
        public void TearDown()
        {
            var person = _context.Persons.Single(x => x.Id == _personId);
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
