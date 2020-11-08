using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaEvaluation.Business;
using IdeaEvaluations.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdeaEvaluation.Controllers
{

    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        public readonly LoginService _login;

        public LoginController(LoginService login)
        {
            _login = login;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            var result = _login.login(user);
            return Ok(result.Id);
        }
    }
}
