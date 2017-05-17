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
    public class BillsController : Controller
    {
        private readonly IBillRepository _bills;
        private readonly ILogger _logger;
        public BillsController(IBillRepository bills, ILogger<BillsController> logger)
        {
            _logger = logger;
            _bills = bills;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            _logger.LogInformation("GET => All");
            return _bills.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Bill Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _bills.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Bill bill)
        {
            _logger.LogInformation("BEGIN => Add bill");
            if (ModelState.IsValid)
            {
                if (_bills.Add(bill))
                {
                    _logger.LogInformation("END <= Add bill");
                    return Ok(bill.Id);
                }
                _logger.LogInformation("FAILED <= Add bill");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add bill");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Bill bill)
        {
            _logger.LogInformation("BEGIN => Edit bill");
            if (ModelState.IsValid)
            {
                if (_bills.Update(bill))
                {
                    _logger.LogInformation("END <= Edit bill");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit bill");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit bill");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove bill");
            if (_bills.Remove(id))
            {
                _logger.LogInformation("END <= Remove bill");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove bill");
            return BadRequest();
        }
    }
}
