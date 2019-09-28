﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository
    {
        private BookServiceContext db;
        public BookRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Book> List()
        {
            return db.Books.Include(p => p.Publisher).Include(a => a.Author).ToList();
        }

        public List<BookBasic> ListBasic()
        {
            return db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
        }

        public BookDetail GetById(int id)
        {
            var book = db.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefault(b => b.Id == id);

            return new BookDetail
            {
                Id = book.Id,
                AuthorId = book.Author.Id,
                AuthorName = $"{book.Author.FirstName} {book.Author.LastName}",
                FileName = book.FileName,
                ISBN = book.ISBN,
                NumberOfPages = book.NumberOfPages,
                Price = book.Price,
                PublisherId = book.Publisher.Id,
                PublisherName = book.Publisher.Name,
                Title = book.Title,
                Year = book.Year
            };
        }
    }
}
