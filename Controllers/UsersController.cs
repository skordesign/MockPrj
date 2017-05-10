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
    [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IRoleRepository _role;
        private readonly ILogger _logger;
        public UsersController(IAccountRepository account, ILogger<ProductsController> logger,
        IRoleRepository role)
        {
            _account = account;
            _logger = logger;
            _role = role;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET => All");
            return new OkObjectResult(_account.All());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _account.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Account account)
        {
            _logger.LogInformation("BEGIN => Add user");
             _logger.LogInformation(account.ToString());
            if (ModelState.IsValid)
            {
                _account.Add(account);
                _logger.LogInformation("END <= Add user");
                return Ok();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add user");
                return BadRequest();
            }
        }
        [HttpGet("role/{roleid}")]
        public object GetRole(int roleid)
        {
            _logger.LogInformation("GET => Role");
            return new ObjectResult(_role.Get(roleid));
        }

        [HttpGet("role")]
        public IActionResult GetRole()
        {
            _logger.LogInformation("GET All => Role");
            return new OkObjectResult(_role.All());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Account account)
        {
            _logger.LogInformation("BEGIN => Edit user");
            if (ModelState.IsValid)
            {
                _account.UpdateWithoutPassword(account);
                _logger.LogInformation("END <= Edit user");
                return Ok();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit user");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("BEGIN => Remove user");
                _account.Remove(id);
                _logger.LogInformation("END <= Remove user");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
