using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorRepository repository;
        IHostingEnvironment _hostingEnvironment;

        public AuthorsController(AuthorRepository authorRepository)
        {
            repository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await repository.ListAll();
            return Ok(authors);
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetAuthorBasic()
        {
            return Ok(await repository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            return Ok(await repository.GetById(id));
        }
    }
}