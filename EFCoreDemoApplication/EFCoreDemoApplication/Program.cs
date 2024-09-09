using EFCoreDemoApplication.DatabaseContext;
using EFCoreDemoApplication.Model;

namespace EFCoreDemoApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting EF Core demo...");

                using var db = new BloggingContext();

                //create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                //REad
                Console.WriteLine("Quering for a blog");
                var blog = db.Blogs.OrderBy(b => b.BlogId)
                    .First();

                Console.WriteLine($"Found blog: {blog.Url}");

                //Update
                Console.WriteLine("updating the blog and adding a post");
                blog.Url = "https://sagarkapase.com";
                blog.Posts.Add(
                        new Post { Title = "Intro", Content = "I am Sagar" });
                db.SaveChanges();
                Console.WriteLine("Updated blog and added a post");
                // Delete
                Console.WriteLine("Deleting the blog");
                db.Remove(blog);
                db.SaveChanges();

                Console.WriteLine("Blog deleted");

                Console.WriteLine("EF Core demo completed.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
