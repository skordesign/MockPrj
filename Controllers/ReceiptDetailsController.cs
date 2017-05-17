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
    public class ReceiptDetailsController : Controller
    {
        private readonly IReceiptDetailsRepository _receiptDetails;
        private readonly ILogger _logger;
        public ReceiptDetailsController(IReceiptDetailsRepository receiptDetails, ILogger<ReceiptDetailsController> logger)
        {
            _logger = logger;
            _receiptDetails = receiptDetails;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<ReceiptNoteDetails> Get()
        {
            _logger.LogInformation("GET => All");
            return _receiptDetails.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ReceiptNoteDetails Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _receiptDetails.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ReceiptNoteDetails receiptDetails)
        {
            _logger.LogInformation("BEGIN => Add receiptDetails");
            if (ModelState.IsValid)
            {
                if (_receiptDetails.Add(receiptDetails))
                {
                    _logger.LogInformation("END <= Add receiptDetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add receiptDetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add receiptDetails");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ReceiptNoteDetails receiptDetails)
        {
            _logger.LogInformation("BEGIN => Edit receiptDetails");
            if (ModelState.IsValid)
            {
                if (_receiptDetails.Update(receiptDetails))
                {
                    _logger.LogInformation("END <= Edit receiptDetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit receiptDetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit receiptDetails");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove receiptDetails");
            if (_receiptDetails.Remove(id))
            {
                _logger.LogInformation("END <= Remove receiptDetails");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove receiptDetails");
            return BadRequest();
        }
    }
}
