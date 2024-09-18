using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Branch Branch { get; set; } //Navigation Property represents the branch the student belongs to.
        public int BranchId { get; set; } //Foreign Key Links the student to a specific branch
        public Address Address { get; set; } // A student has one address ( one to one relationship )
        public ICollection<Course> Courses { get; set; } //A collection representing the many to many relationship between students and courses
    }
}
