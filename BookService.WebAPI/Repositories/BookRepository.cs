using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository : MappingRepository<Book>
    {
        public BookRepository(BookServiceContext context, IMapper mapper) : base(context, mapper)
        {
                
        }
        public async Task<List<Book>> GetAllInclusive()
        {
            return await db.Books
                .Include(p => p.Publisher)
                .Include(a => a.Author)
                .ToListAsync();
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only) using AutoMapper
            return await db.Books.ProjectTo<BookBasic>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return mapper.Map<BookDetail>(
                    await db.Books
                        .Include(a => a.Author)
                        .Include(p => p.Publisher)
                        .FirstOrDefaultAsync(b => b.Id == id)
                
                );
        }
    }
}
