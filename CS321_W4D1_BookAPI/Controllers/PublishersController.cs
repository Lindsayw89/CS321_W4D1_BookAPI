using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CS321_W4D1_BookAPI.Services;
using CS321_W4D1_BookAPI.ApiModels;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        //dependency injection start place
        private readonly IPublisherService _publisherService;
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;

        }
        // GET: api/Publishers
        [HttpGet]
        public IActionResult Get()
        {

            // TODO: convert domain models to apimodels
            var publisherModels = _publisherService
                .GetAll()
            .ToApiModels(); // convert Books to BookModels UNSURE

            return Ok(publisherModels);


           // return Ok( _publisherService.GetAll().ToAPiModels());
           // why didn't this above line work??
        }

        // GET: api/Publishers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.Get(id).ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST: api/Publishers
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)    
        {
            try { 
            // TODO: convert apimodel to domain model
            // add the new book
            _publisherService.Add(newPublisher.ToDomainModel());
            //UNSURE

        }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
    }

            return CreatedAtAction("Get", new { Id = newPublisher.Id
}, newPublisher);


        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher )
        {

            var publisher = _publisherService.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
           
            return Ok(publisher.ToApiModel());



        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }
}
