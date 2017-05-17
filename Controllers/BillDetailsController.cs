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
    public class BillDetailsController : Controller
    {
        private readonly IBillDetailsRepository _billDetails;
        private readonly ILogger _logger;
        public BillDetailsController(IBillDetailsRepository billDetails, ILogger<BillDetailsController> logger)
        {
            _logger = logger;
            _billDetails = billDetails;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<BillDetails> Get()
        {
            _logger.LogInformation("GET => All");
            return _billDetails.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BillDetails Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _billDetails.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BillDetails billDetails)
        {
            _logger.LogInformation("BEGIN => Add billdetails");
            if (ModelState.IsValid)
            {
                if (_billDetails.Add(billDetails))
                {
                    _logger.LogInformation("END <= Add billdetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add billdetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add billdetails");
                return BadRequest();
            }
        }
        [HttpPost("/list")]
        public IActionResult PostList([FromBody]List<BillDetails> billDetailses)
        {
            _logger.LogInformation("BEGIN => Add list billdetails");
            if (_billDetails.AddList(billDetailses))
            {
                _logger.LogInformation("END <=  Add list billdetails");
                return Ok();
            }
            _logger.LogInformation("FAILED <=  Add list billdetails");
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BillDetails billDetails)
        {
            _logger.LogInformation("BEGIN => Edit billdetails");
            if (ModelState.IsValid)
            {
                if (_billDetails.Update(billDetails))
                {
                    _logger.LogInformation("END <= Edit billdetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit billdetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit billdetails");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove billdetails");
            if (_billDetails.Remove(id))
            {
                _logger.LogInformation("END <= Remove billdetails");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove billdetails");
            return BadRequest();
        }
    }
}
