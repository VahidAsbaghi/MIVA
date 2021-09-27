using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            return Ok();
        }
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public enum UserRole
    {
        Anonymous,
        Admin,
        Customer
    }

}
