using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Infrastructure.Helper;
using Microsoft.AspNetCore.Authorization;

namespace Login.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public LoginController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [AllowAnonymous]
        [HttpPost()]
        //[Route("route")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            var token=await _authenticateService.Authenticate(credentials);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }

    public enum UserRole
    {
        Anonymous,
        Admin,
        Customer
    }

}
