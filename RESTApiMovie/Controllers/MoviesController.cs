using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieDLL;
using RESTApiMovie.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTApiMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //ref til manager
        private MoviesManager _manager = new MoviesManager();
        // GET: api/<MoviesController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            IEnumerable<Movie> result = _manager.GetAll();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<MoviesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            Movie result = _manager.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        // POST api/<ValuesController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie addMovie)
        {
            Movie result = _manager.AddMovie(addMovie);
            if (result == null)
            {
                return null;
            }
            return Created($"/api/movies/{result.Id}", result);
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
