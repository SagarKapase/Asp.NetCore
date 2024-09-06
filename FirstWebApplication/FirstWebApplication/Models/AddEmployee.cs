using System.ComponentModel.DataAnnotations;

namespace FirstWebApplication.Models
{
    public class AddEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100,ErrorMessage = "Name cannot exceeds 100 characters")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
    }
}
