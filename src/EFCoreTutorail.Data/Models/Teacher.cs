using System;
namespace EFCoreTutorail.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {

        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
