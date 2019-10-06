using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetBooks()
        {
            var books = await repository.ListAll();
            return Ok(books);
        }

        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await repository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok(await repository.GetById(id));
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
        public async Task<IActionResult> ImageById(int id)
        {
            //var filename = repository.GetById(id).Result.FileName;
            var book = await repository.GetById(id);
            
            var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", book.FileName);
            return PhysicalFile(image, "image/jpeg");
        }
    }
}