using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;

namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RolesService _RolesService;

        public RolesController(RolesService RolesService)
        {
            _RolesService = RolesService;

        }

        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetRoles()
        {
            var articulo = _RolesService.GetRoles();
            return Ok(articulo);
        }
    }
}