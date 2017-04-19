using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockPrj.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using MockPrj.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockPrj.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IRoleRepository _role;
        private readonly ILogger _logger;
        public AccountController(IAccountRepository account, IRoleRepository role,
            ILogger<AccountController> logger)
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
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(Account o)
        {
            if (ModelState.IsValid)
            {
                o.RoleId = 1;
                _logger.LogInformation("BEGIN => Register");
                if (_account.Add(o))
                {
                    _logger.LogInformation("END <= Register");
                    return Ok();
                }
            }
            _logger.LogError("FAILED <= Register");
            return BadRequest();
        }
        [HttpPut]
        [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "User")]
        public IActionResult Edit(Account o)
        {
            try
            {
                _logger.LogInformation("BEGIN => Edit Account");
                _account.Update(o);
                _logger.LogInformation("END <= Edit Account");
                return Ok();
            }
            catch
            {
                _logger.LogError("FAILED: Edit Account");
                return BadRequest();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RequestPassword(string email)
        {
            //send mail
            return Ok();
        }
        
    }
}
