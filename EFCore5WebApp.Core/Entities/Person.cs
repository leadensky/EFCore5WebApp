using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5WebApp.Core.Entities
{
    [Table("Persons", Schema = "dbo")]
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public List<Person> Parents { get; set; } = new List<Person>();
        public List<Person> Children { get; set; } = new List<Person>();
        public DateTime CreatedOn { get; set; }
    }
}
