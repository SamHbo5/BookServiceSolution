using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository repository;
        IHostingEnvironment _hostingEnvironment;

        public BooksController(BookRepository bookRepository)
        {
            repository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(repository.List());
        }

        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBookBasic()
        {
            return Ok(repository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        [HttpGet]
        [Route("ImageById/{id}")]
        public IActionResult ImageById(int id)
        {
            var filename = repository.GetById(id).FileName;
            var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }
    }
}