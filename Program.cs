using Microsoft.EntityFrameworkCore;

public class Student
{
    public int Id { get; set; }  // Primary key
    public required string Name { get; set; }
    public int Age { get; set; }
}


public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use SQL Server as the database provider
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SchoolContext())
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Create a new student
            var student = new Student
            {
                Name = "John Doe",
                Age = 22
            };

            // Add the student to the database
            context.Students.Add(student);
            context.SaveChanges(); // Save changes to the database

            Console.WriteLine("Student added to the database!");
        }
    }
}
