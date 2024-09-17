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
                                                                                                    StudentCount = studentGroup.Count(),
                                                                                                    //retrive the list of students in each group
                                                                                                    Students = studentGroup.ToList()
                                                                                                }).ToList();

                    if (groupedStudentQuerySyntax.Any())
                    {
                        foreach (var group in groupedStudentQuerySyntax)
                        {
                            Console.WriteLine($"\nBranch: {group.BranchName}, Number of Students: {group.StudentCount}");

                            // Display details of each student in the branch
                            foreach (var student in group.Students)
                            {
                                Console.WriteLine($"\tStudent: {student.FirstName} {student.LastName}, Email: {student.Email}, Enrollment Date: {student.EnrollmentDate.ToShortDateString()}");
                            }
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

            #region Joining using LINQ to Entities in Entity Framework Core

            try
            {
                using (var context = new MyApplicationDbContext())
                {
                    var joiningTableQuerySyntax = (from student in context.Students
                                                   join branch in context.Branches
                                                   on student.Branch.BranchId equals branch.BranchId
                                                   select new
                                                   {
                                                       student.FirstName,
                                                       student.LastName,
                                                       student.Email,
                                                       student.EnrollmentDate,
                                                       branch.BranchName
                                                   }).ToList();

                    // Check if any results are found
                    if (joiningTableQuerySyntax.Any())
                    {
                        // Iterate through the results and display the details
                        foreach (var item in joiningTableQuerySyntax)
                        {
                            // Output the student's details along with the branch name
                            Console.WriteLine($"Student: {item.FirstName} {item.LastName}, Email: {item.Email}, Enrollment Date: {item.EnrollmentDate.ToShortDateString()}, Branch: {item.BranchName}");
                        }
                    }
                    else
                    {
                        // Output if no students are found
                        Console.WriteLine("No students found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            #endregion
        }
    }
}