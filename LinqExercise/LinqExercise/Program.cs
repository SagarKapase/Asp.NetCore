namespace LinqExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Sagar", "John", "Thomas", "Shelby", "Peaky Blinder" };

            //Linq query
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;

            //query execution
            foreach (var name in myLinqQuery)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
    }
}
