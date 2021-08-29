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
    public class ManyToManyTests : AppDbContextTestsBase
    {
        private List<Person> _family;

        public override void Setup()
        {
            base.Setup();
            _family = new List<Person>();

            var parent1 = CreateClarkKent();
            var parent2 = new Person
            {
                FirstName = "Lois",
                LastName = "Lane",
                EmailAddress = "Lois@dailybugle.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = "1234 Fake Street",
                        City = "Chicago",
                        State = "IL",
                        ZipCode = "60652",
                        Country = "USA"
                    }
                }
            };

            var child1 = new Person
            {
                FirstName = "David",
                LastName = "Kent",
                EmailAddress = "Lois@dailybugle.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = "1234 Fake Street",
                        City = "Chicago",
                        State = "IL",
                        ZipCode = "60652",
                        Country = "USA"
                    }
                }
            };

            var child2 = new Person
            {
                FirstName = "Anna",
                LastName = "Kent",
                EmailAddress = "Lois@dailybugle.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = "1234 Fake Street",
                        City = "Chicago",
                        State = "IL",
                        ZipCode = "60652",
                        Country = "USA"
                    }
                }
            };

            _context.Persons.Add(parent1);
            _context.Persons.Add(parent2);
            _context.Persons.Add(child1);
            _context.Persons.Add(child2);

            parent1.Children.Add(child1);
            parent1.Children.Add(child2);

            parent2.Children.Add(child1);
            parent2.Children.Add(child2);

            child1.Parents.Add(parent1);
            child1.Parents.Add(parent2);
            child2.Parents.Add(parent1);
            child2.Parents.Add(parent2);

            _family.Add(parent1);
            _family.Add(parent2);
            _family.Add(child1);
            _family.Add(child2);

            _context.SaveChanges();
        }

        [Test]
        public void GetParentsFromChildren()
        {
            var daughter = _family.Single(x => x.FirstName == "Anna");
            var son = _family.Single(x => x.FirstName == "David");
            Assert.AreEqual(2, daughter.Parents.Count);
            Assert.AreEqual(2, son.Parents.Count);
        }

        [Test]
        public void GetChildrenFromParents()
        {
            var father = _family.Single(x => x.FirstName == "Clark");
            var mother = _family.Single(x => x.FirstName == "Lois");
            Assert.AreEqual(2, father.Children.Count);
            Assert.AreEqual(2, mother.Children.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Persons.RemoveRange(_family);
            _context.SaveChanges();
        }
    }
}
