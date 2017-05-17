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
    public class ReceiptsController : Controller
    {
        private readonly IReceiptRepository _receipts;
        private readonly ILogger _logger;
        public ReceiptsController(IReceiptRepository receipts, ILogger<ReceiptsController> logger)
        {
            _logger = logger;
            _receipts = receipts;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<ReceiptNote> Get()
        {
            _logger.LogInformation("GET => All");
            return _receipts.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ReceiptNote Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _receipts.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ReceiptNote receipt)
        {
            _logger.LogInformation("BEGIN => Add receipt");
            if (ModelState.IsValid)
            {
                if (_receipts.Add(receipt))
                {
                    _logger.LogInformation("END <= Add receipt");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add receipt");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add receipt");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ReceiptNote receipt)
        {
            _logger.LogInformation("BEGIN => Edit receipt");
            if (ModelState.IsValid)
            {
                if (_receipts.Update(receipt))
                {
                    _logger.LogInformation("END <= Edit receipt");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit receipt");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit receipt");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove receipt");
            if (_receipts.Remove(id))
            {
                _logger.LogInformation("END <= Remove receipt");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove receipt");
            return BadRequest();
        }
    }
}
