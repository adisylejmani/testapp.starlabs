using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
