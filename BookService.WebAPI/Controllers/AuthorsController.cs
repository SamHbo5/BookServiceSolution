﻿using System;
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
        public IActionResult GetAuthors()
        {
            return Ok(repository.List());
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetAuthorBasic()
        {
            return Ok(repository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthor(int id)
        {
            return Ok(repository.GetById(id));
        }
    }
}