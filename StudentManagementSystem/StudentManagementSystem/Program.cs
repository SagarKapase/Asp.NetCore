using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    //method synctax
                    var studentsWithAddresssMethod = context.Students
                        .Include(x => x.Address)
                        .Include(a => a.Branch)
                        .Include(b => b.Courses)
                        .ToList();

                    Console.WriteLine(); // Display a new line before displaying the data
                    foreach (var student in studentsWithAddresssMethod)
                    {
                        if (student.Address != null)
                        {
                            // Address exists, display the full address details
                            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: {student.Address.Street}, {student.Address.City}, {student.Address.State},Course Name : {student.Courses}");
                        }
                        else
                        {
                            // Address is null, display "No Address"
                            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: No Address");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
