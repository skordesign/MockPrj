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
    public class DeliveriyDetailsController : Controller
    {
        private readonly IDeliveryDetailsRepository _deliveriyDetails;
        private readonly ILogger _logger;
        public DeliveriyDetailsController(IDeliveryDetailsRepository deliveriyDetails, ILogger<DeliveriesController> logger)
        {
            _logger = logger;
            _deliveriyDetails = deliveriyDetails;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<DeliveryNoteDetails> Get()
        {
            _logger.LogInformation("GET => All");
            return _deliveriyDetails.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public DeliveryNoteDetails Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _deliveriyDetails.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]DeliveryNoteDetails deliveryDetails)
        {
            _logger.LogInformation("BEGIN => Add deliveryDetails");
            if (ModelState.IsValid)
            {
                if (_deliveriyDetails.Add(deliveryDetails))
                {
                    _logger.LogInformation("END <= Add deliveryDetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add deliveryDetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add deliveryDetails");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DeliveryNoteDetails deliveryDetails)
        {
            _logger.LogInformation("BEGIN => Edit deliveryDetails");
            if (ModelState.IsValid)
            {
                if (_deliveriyDetails.Update(deliveryDetails))
                {
                    _logger.LogInformation("END <= Edit deliveryDetails");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit deliveryDetails");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit deliveryDetails");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove deliveryDetails");
            if (_deliveriyDetails.Remove(id))
            {
                _logger.LogInformation("END <= Remove deliveryDetails");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove deliveryDetails");
            return BadRequest();
        }
    }
}
