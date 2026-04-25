using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp5
{
    #region Entities

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public int Pages { get; set; }

        public int PublishedYear { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Biography { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    // many-to-many
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    #endregion

    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BookStoreDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new BookStoreContext();

            db.Database.EnsureCreated();

            Console.WriteLine("BookStore Database Created Successfully ✅");
        }
    }
}