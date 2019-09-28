using BookService.WebAPI.Data;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext db;

        public AuthorRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Author> List()
        {
            return db.Authors.ToList();
        }

        public List<AuthorBasic> ListBasic()
        {
            return db.Authors.Select(a => new AuthorBasic
            {
                Id = a.Id,
                Name = $"{a.FirstName} {a.LastName}"
            }).ToList();
        }

        public Author GetById(int id)
        {
            return db.Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}
