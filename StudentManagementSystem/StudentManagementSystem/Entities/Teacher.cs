using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
