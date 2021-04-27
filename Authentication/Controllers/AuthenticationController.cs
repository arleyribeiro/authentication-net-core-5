using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using Authentication.Infrastructure;
using Authentication.Repositories;
using Authentication.Models;
using Authentication.Dtos.Request;
using Authentication.Services;

namespace Authentication.Controllers
{
    [Route("v1/account")]
    public class AuthenticationController : Controller
    {
        private readonly IAccountService _accountService;
        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] AuthenticateRequest model)
        {
            var token = await _accountService.Login(model.Username, model.Password);
            return new
            {
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

    }
}
