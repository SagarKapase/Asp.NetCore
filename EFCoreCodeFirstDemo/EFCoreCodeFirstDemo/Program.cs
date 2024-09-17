using EFCoreCodeFirstDemo.Entities;
using EFCoreCodeFirstDemo.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Searching using LINQ to Entities in Entity Framework Core

            /*try
            {
                //Initialize the DbContext
                using (var context = new MyApplicationDbContext())
                {
                    string searchFirstName = "Alice";

                    //Linq Query syntax
                    var searchResultQs = (from student in context.Students
                                          where student.FirstName == searchFirstName
                                          select student).ToList();
                    //Linq method syntax
                    var searchResultMS = context.Students.Where(s => s.FirstName == searchFirstName).ToList();

                    if (searchResultQs.Any())
                    {
                        foreach (var student in searchResultQs)
                        {
                            Console.WriteLine($"Student Found: {student.FirstName} {student.LastName}, Email: {student.Email}");
                        }
                    }
                    else
                    {
                        // Output if no student is found
                        Console.WriteLine("No student found with the given first name.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            #endregion

            #region Filtering using LINQ to Entities in Entity Framework Core

            /*try
            {
                using (var context = new MyApplicationDbContext())
                {
                    string branchName = "Computer Science Engineering";
                    string gender = "Female";

                    //Linq query syntax to filter students by branch name and gender
                    var filteredStudentsQS = (from student in context.Students.Include(s => s.Branch)
                                              where student.Branch.BranchName == branchName && student.Gender == gender
                                              select student).ToList();

                    var filteredStudentMS = context.Students
                        .Include(s => s.Branch)
                        .Where(s => s.Branch.BranchName == branchName && s.Gender == gender).ToList();

                    if (filteredStudentsQS.Any())
                    {
                        foreach (var student in filteredStudentsQS)
                        {
                            Console.WriteLine($"Student Found: {student.FirstName} {student.LastName}, Email: {student.Email},Branch:{student.Branch.BranchName},Gender:{student.Gender}");
                        }
                    }else
                    {
                        Console.WriteLine("Student Not Found !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            #endregion

            #region Sorting using LINQ to Entities in Entity Framework Core

            /*try
            {
                using (var context = new MyApplicationDbContext())
                {
                    string branchName = "Computer Science Engineering";
                    string gender = "Female";

                    //Linq query syntax to filter students by branch name and gender
                    var filteredStudentsQS = (from student in context.Students
                                              orderby student.Gender ascending,
                                              student.EnrollmentDate descending
                                              select student).ToList();

                    var sortedStudentsMethodSyntax = context.Students
                                                            .OrderBy(s => s.Gender) // Primary sort by Gender in ascending order
                                                            .ThenByDescending(s => s.EnrollmentDate) // Secondary sort by EnrollmentDate in descending order
                                                            .ToList();

                    if (filteredStudentsQS.Any())
                    {
                        foreach (var student in filteredStudentsQS)
                        {
                            Console.WriteLine($"Student: {student.LastName} {student.FirstName}, Gender: {student.Gender}, Enrollment Date: {student.EnrollmentDate.ToShortDateString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            #endregion

            #region Grouping using LINQ to Entities in Entity Framework Core

            /*try
            {
                using (var context = new MyApplicationDbContext())
                {
                    var groupedStudentQuerySyntax = (from student in context.Students
                                                     .Include(s => s.Branch)
                                                     group student by student.Branch.BranchName into studentGroup
                                                     select
                                                                                                new
                                                                                                {
                                                                                                    BranchName = studentGroup.Key,
                                                                                                    StudentCount = studentGroup.Count()
                                                                                                }).ToList();

                    if (groupedStudentQuerySyntax.Any())
                    {
                        foreach (var group in groupedStudentQuerySyntax)
                        {
                            Console.WriteLine($"\nBranch: {group.BranchName}, Number of Students: {group.StudentCount}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students found.");
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/
            #endregion
        }
    }
}