using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockPrj.Models;
using MockPrj.Repositories;

namespace MockPrj.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly ILogger _logger;
        public CategoriesController(ICategoryRepository category, ILogger<CategoriesController> logger)
        {
            _category = category;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            _logger.LogInformation("GET => All");
            return _category.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _category.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            _logger.LogInformation("BEGIN => Add category");
            if (ModelState.IsValid)
            {
                if (_category.Add(category))
                {
                    _logger.LogInformation("END <= Add category");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add category");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add category");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            _logger.LogInformation("BEGIN => Edit category");
            if (ModelState.IsValid)
            {
                if (_category.Update(category))
                {
                    _logger.LogInformation("END <= Edit category");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit category");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit category");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove category");
            if (_category.Remove(id))
            {
                _logger.LogInformation("END <= Remove category");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove category");
            return BadRequest();
        }
    }
}
