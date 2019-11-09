using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Data
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>().ToTable("Reader")
                .HasData(
                    new Reader(1, "Jean-Claude", "Godefroid"),
                    new Reader(2, "Phillipe", "Champagne"),
                    new Reader(3, "Baptiste", "Bourgogne")
                );

            modelBuilder.Entity<Rating>().ToTable("Rating")
                .HasData(
                    new Rating(1, 1, 1, 3),
                    new Rating(2, 2, 2, 4),
                    new Rating(3, 1, 3, 3),
                    new Rating(4, 1, 7, 2),
                    new Rating(5, 2, 4, 5),
                    new Rating(6, 2, 5, 4),
                    new Rating(7, 3, 6, 2),
                    new Rating(8, 3, 1, 2)
                    );

            // Singularize table names
            modelBuilder.Entity<Publisher>()
                .ToTable("Publisher")
                .HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "IT-publishers",
                    Country = "UK"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "FoodBooks",
                    Country = "Sweden"
                });

            modelBuilder.Entity<Author>()
                .ToTable("Author")
                .HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Sharp",
                    BirthDate = new DateTime(1980, 5, 20)
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Sophie",
                    LastName = "Netty",
                    BirthDate = new DateTime(1992, 3, 4)
                },
                new Author
                {
                    Id = 3, FirstName = "Elisa",
                    LastName = "Yammy",
                    BirthDate = new DateTime(1996, 8, 12)
                });

            // using ANONYMOUS CLASS to construct Books in Db (AuthorId and PublisherId are no real properties)
            modelBuilder.Entity<Book>()
                .ToTable("Book")
                .HasData(
                new
                {
                    Id = 1,
                    ISBN = "123456789",
                    Title = "Learning C#",
                    NumberOfPages = 420,
                    FileName = "book1.jpg",
                    AuthorId = 1,
                    PublisherId = 1,
                    Price = 20M,
                    Year = "2017"
                },
                new
                {
                    Id = 2,
                    ISBN = "45689132",
                    Title = "Mastering Linq",
                    NumberOfPages = 360,
                    FileName = "book2.jpg",
                    AuthorId = 2,
                    PublisherId = 1,
                    Price = 25M,
                    Year = "2019"
                },
                new
                {
                    Id = 3,
                    ISBN = "15856135",
                    Title = "Mastering Xamarin",
                    NumberOfPages = 360,
                    FileName = "book3.jpg",
                    AuthorId = 1,
                    PublisherId = 1,
                    Price = 29M,
                    Year = "2018"
                },
                new
                {
                    Id = 4,
                    ISBN = "56789564",
                    Title = "Exploring ASP.Net Core 2.0",
                    NumberOfPages = 360,
                    FileName = "book1.jpg",
                    AuthorId = 2,
                    PublisherId = 1,
                    Price = 30M,
                    Year = "2019"
                },
                new
                {
                    Id = 5,
                    ISBN = "234546684",
                    Title = "Unity Game Development",
                    NumberOfPages = 420,
                    FileName = "book2.jpg",
                    AuthorId = 2,
                    PublisherId = 1,
                    Price = 40M,
                    Year = "2017"
                },
                new
                {
                    Id = 6,
                    ISBN = "789456258",
                    Title = "Cooking is fun",
                    NumberOfPages = 40,
                    FileName = "book3.jpg",
                    AuthorId = 3,
                    PublisherId = 2,
                    Price = 19M,
                    Year = "2016"
                },
                new
                {
                    Id = 7,
                    ISBN = "94521546",
                    Title = "Secret recipes",
                    NumberOfPages = 53,
                    FileName = "book3.jpg",
                    AuthorId = 3,
                    PublisherId = 2,
                    Price = 40M,
                    Year = "2019"
                });


            modelBuilder.Entity<Publisher>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate(); 
            
            modelBuilder.Entity<Author>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate(); 
            
            modelBuilder.Entity<Book>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

        }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Rating> Ratings { get; set; }


    }
}
