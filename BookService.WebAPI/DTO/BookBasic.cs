using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.DTO
{
    public class BookBasic
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLatName { get; set; }
        public int PublisherId { get; set; }
        public int PublisherName { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
