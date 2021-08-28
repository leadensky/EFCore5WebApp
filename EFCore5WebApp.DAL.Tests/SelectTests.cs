using EFCore5WebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5WebApp.DAL.Tests
{

    [TestFixture]
    public class SelectTests : AppDbContextTestsBase
    {
        [Test]
        public void GetAllPersons()
        {
            IEnumerable<Person> persons = _context.Persons.ToList();
            Assert.GreaterOrEqual(2, persons.Count());
        }

        [Test]
        public void PersonsHaveAddresses()
        {
            List<Person> persons = _context.Persons.Include(x => x.Addresses).ToList();
            Assert.AreEqual(1, persons[0].Addresses.Count);
            Assert.AreEqual(2, persons[1].Addresses.Count);
        }

        [Test]
        public void HaveLookUpRecords()
        {
            var lookUps = _context.LookUps.ToList();
            var countries = lookUps.Where(x => x.LookUpType == LookUpType.Country).ToList();
            var states = lookUps.Where(x => x.LookUpType == LookUpType.State).ToList();

            Assert.AreEqual(1, countries.Count);
            Assert.AreEqual(51, states.Count); 
        }
    }
}
