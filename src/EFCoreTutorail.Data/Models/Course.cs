using System;
using System.Collections.Generic;

namespace EFCoreTutorail.Data.Models
{
    public class Course
    {
        public Course()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
