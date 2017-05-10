using Microsoft.AspNetCore.Mvc;
using MockPrj.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using MockPrj.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockPrj.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IRoleRepository _role;
        private readonly ILogger _logger;
        public AccountsController(IAccountRepository account, IRoleRepository role,
            ILogger<AccountsController> logger)
        {
            _account = account;
            _role = role;
            _logger = logger;
        }

        [HttpDelete]
        [Authorize(ActiveAuthenticationSchemes = "Bearer")]
        public bool Logout()
        {
            _logger.LogInformation("User logged out");
            return true;
        }
        [HttpPut("{id}")]
        [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "User")]
        public IActionResult Edit(int id,[FromBody]Account o)
        {
            try
            {
                _logger.LogInformation("BEGIN => Edit Account");
                if (_account.Update(o))
                {
                    _logger.LogInformation("END <= Edit Account");
                    return Ok();
                }
                _logger.LogError("FAILED: Edit Account");
                return BadRequest();
            }
            catch
            {
                _logger.LogError("FAILED: Edit Account");
                return BadRequest();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RequestPassword([FromBody]string email)
        {
            //send mail
            return Ok();
        }
        [HttpGet("{id}")]
        [Authorize(ActiveAuthenticationSchemes = "Bearer")]
        public IActionResult GetInfo(int id)
        {
            return new ObjectResult(_account.Get(id));
        }
        [HttpGet("{id}")]
        [Authorize(ActiveAuthenticationSchemes = "Bearer")]
        public IActionResult GetRole(int id)
        {
            _logger.LogInformation(@"GET => Role Id {id}", id);
            return new ObjectResult(_role.Get(id));
        }
    }
}
