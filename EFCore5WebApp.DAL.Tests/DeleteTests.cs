using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5WebApp.DAL.Tests
{
    public class DeleteTests : AppDbContextTestsBase
    {
        public override void Setup()
        {
            base.Setup();
            _context.Add(CreateClarkKent());
            _context.SaveChanges();
        }

        [Test]
        public void DeletePerson()
        {
            var existing = _context.Persons.Single(x => x.FirstName == "Clark" && x.LastName == "Kent");
            var personId = existing.Id;

            _context.Persons.Remove(existing);
            _context.SaveChanges();

            var found = _context.Persons.SingleOrDefault(x => x.Id == personId);
            Assert.IsNull(found);

            var addresses = _context.Addresses.Where(x => x.PersonId == personId);
            Assert.AreEqual(0, addresses.Count());
        }

        
    }
}
