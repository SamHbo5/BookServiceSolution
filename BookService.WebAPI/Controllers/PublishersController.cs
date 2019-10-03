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
    public class PublishersController : ControllerBase
    {
        PublisherRepository repository;
        IHostingEnvironment _hostingEnvironment;

        public PublishersController(PublisherRepository publisherRepository)
        {
           repository = publisherRepository;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            var publishers = await repository.ListAll(); 
            return Ok(publishers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // PUT: api/Publishers/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute] int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            Publisher p = await repository.Update(publisher);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // POST: api/Publishers 
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await repository.Add(publisher);
            return CreatedAtAction("GetPublisher", new { id = publisher.Id }, publisher);
        }

        // DELETE: api/Publishers/3 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await repository.Delete(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }
    }
}