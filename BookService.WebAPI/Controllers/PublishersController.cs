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
    public class PublishersController : ControllerBase
    {
        PublisherRepository repository;
        IHostingEnvironment _hostingEnvironment;

        public PublishersController(PublisherRepository publisherRepository)
        {
           repository = publisherRepository;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Ok(repository.List());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPublisher(int id)
        {
            return Ok(repository.GetById(id));
        }
    }
}