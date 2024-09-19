using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Eager Loading in Entity Framework Core
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
            #endregion in 

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

            #region Explicit Loading in Entity Framework Core
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    Console.WriteLine("\nExplicit Loading Student Related Data\n");

                    // Load a student (only student data is loaded initially)
                    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
                    if (student != null)
                    {
                        Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
                        //Explicitly load the branch navigation property for the student
                        context.Entry(student).Reference(s => s.Branch).Load();

                        if (student.Branch != null)
                        {
                            Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
                        }
                        else
                        {
                            Console.WriteLine("\nBranch data not available.\n");
                        }

                        // Explicitly load the Address navigation property for the student
                        context.Entry(student).Reference(s => s.Address).Load();
                        // Check if Address is null before accessing its properties
                        if (student.Address != null)
                        {
                            Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode} \n");
                        }
                        else
                        {
                            Console.WriteLine("\nAddress data not available.\n");
                        }

                        //Explicitl load the Courses Collection navigation property for the student
                        context.Entry(student).Collection(s => s.Courses).Load();

                        // Loop through the loaded courses and display course names
                        foreach (var course in student.Courses)
                        {
                            Console.WriteLine($"Course: {course.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            #endregion
        }
    }
}
