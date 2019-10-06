﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerCrudBase<Author, AuthorRepository>
    {
        public AuthorsController(AuthorRepository authorRepository) : base(authorRepository)
        {
        }

        // GET: api/Authors/Basic 
        [HttpGet] [Route("Basic")] 
        public async Task<IActionResult> GetAuthorBasic() 
        { 
            var authors = await repository.ListBasic(); 
            return Ok(authors); 
        }
    }
}