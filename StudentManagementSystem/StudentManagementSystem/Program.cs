using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Eager Loading
            /*using (var context = new EFCoreDbContext())
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
            }*/
            #endregion

            #region Lazy Loading in Entity Framework Core

            /*using (var context = new EFCoreDbContext())
            {
                try
                {
                    // Lazy Loading Example
                    Console.WriteLine("Lazy Loading Student and related data\n");

                    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
                    // Display basic student information
                    Console.WriteLine($"\nStudent Id: {student?.StudentId}, Name: {student?.FirstName} {student?.LastName}, Gender: {student?.Gender} \n");

                    // Accessing the Branch property triggers lazy loading
                    // EF Core will issue a SQL query to load the related Branch
                    if (student != null)
                    {
                        Console.WriteLine($"\nBranch Location: {student.Branch?.BranchLocation}, Email: {student.Branch?.BranchEmail}, Phone: {student.Branch?.BranchPhoneNumber}  \n");
                        // Accessing the Address property triggers lazy loading
                        // EF Core will issue a SQL query to load the related Address
                        Console.WriteLine($"\nAddress: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}, Pin: {student.Address?.PostalCode} \n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }*/
            
            #endregion
        }
    }
}
