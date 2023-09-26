using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbFirstApi.DataConnections;
using dbFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbFirstApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthorController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await _applicationDbContext.Authors.Include(author => author.BookAuthors).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

