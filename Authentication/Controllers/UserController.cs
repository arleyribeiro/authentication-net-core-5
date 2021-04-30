using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Authentication.Infrastructure;
using Authentication.Repositories;
using Authentication.Repositories.Interfaces;
using Authentication.Models;
using Authentication.Dtos.Request;
using Authentication.Services.Interfaces;

namespace Authentication.Controllers
{
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<dynamic>> GetAllAsync()
        {
            var users = await _accountService.GetAllAsync().ConfigureAwait(false);
            return new
            {
                users = users
            };
        }
    }
}
