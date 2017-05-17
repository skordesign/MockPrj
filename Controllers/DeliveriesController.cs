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
    public class DeliveriesController : Controller
    {
        private readonly IDeliveryRepository _deliveries;
        private readonly ILogger _logger;
        public DeliveriesController(IDeliveryRepository deliveries, ILogger<DeliveriesController> logger)
        {
            _logger = logger;
            _deliveries = deliveries;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<DeliveryNote> Get()
        {
            _logger.LogInformation("GET => All");
            return _deliveries.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public DeliveryNote Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _deliveries.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]DeliveryNote delivery)
        {
            _logger.LogInformation("BEGIN => Add delivery");
            if (ModelState.IsValid)
            {
                if (_deliveries.Add(delivery))
                {
                    _logger.LogInformation("END <= Add delivery");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add delivery");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add delivery");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DeliveryNote delivery)
        {
            _logger.LogInformation("BEGIN => Edit delivery");
            if (ModelState.IsValid)
            {
                if (_deliveries.Update(delivery))
                {
                    _logger.LogInformation("END <= Edit delivery");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Edit delivery");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit delivery");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("BEGIN => Remove delivery");
            if (_deliveries.Remove(id))
            {
                _logger.LogInformation("END <= Remove delivery");
                return Ok();
            }
            _logger.LogInformation("FAILED <= Remove delivery");
            return BadRequest();
        }
    }
}
