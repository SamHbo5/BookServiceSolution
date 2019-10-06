using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(BookServiceContext context) : base(context)
        {
                
        }
        public async Task<List<Book>> GetallInclusive()
        {
            return await db.Books
                .Include(p => p.Publisher)
                .Include(a => a.Author)
                .ToListAsync();
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            return await db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            var book = await GetAll()
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);

            var bookDetail = new BookDetail
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

            return bookDetail;
        }
    }
}
