using System;
using System.Collections.Generic;
using System.Linq;
using H3_CASE_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using H3_CASE_API.Services;

namespace H3_CASE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(MainDBContext _context, HttpContext http, ITokenService service, Login login)
        {
            if (!string.IsNullOrEmpty(login.UserName) &&
              !string.IsNullOrEmpty(login.Password))
            {
                var userModel = await _context.Users.Where(u => u.UserName == login.UserName && u.Password == login.Password).FirstOrDefaultAsync();
                if (userModel == null)
                {
                    http.Response.StatusCode = 401;
                    await http.Response.WriteAsJsonAsync(new { Message = "Yor Are Not Authorized!" });
                    return NotFound();
                }

                var token = service.GetToken(userModel);
                await http.Response.WriteAsJsonAsync(new { token });
                return Ok(token);
            }
        }


        [HttpGet("jwt")]
        [Authorize]
        public IEnumerable<int> JwtAuth()
        {
            var username = User.Identity.Name;
            _logger.LogInformation($"User [{username}] is visiting jwt auth with token {1}");
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(x => rng.Next(0, 100));
        }


        [HttpGet("basic")]
        //[BasicAuth] // You can optionally provide a specific realm --> [BasicAuth("my-realm")]
        public IEnumerable<int> BasicAuth()
        {
            _logger.LogInformation("basic auth");
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(x => rng.Next(0, 100));
        }

        [HttpGet("basic-logout")]
        //[BasicAuth]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult BasicAuthLogout()
        {
            _logger.LogInformation("basic auth logout");
            // NOTE: there's no good way to log out basic authentication. This method is a hack.
            HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"My Realm\"";
            return new UnauthorizedResult();
        }
    }
}
