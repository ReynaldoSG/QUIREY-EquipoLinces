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
    public class VendedoresController: ControllerBase
    {
        private readonly VendedoresService _VendedoresService;

    public VendedoresController(VendedoresService vendedoresService) 
    {
            _VendedoresService = vendedoresService;
    }


        [HttpGet("Get")] 
        public IActionResult GetVendedores()
        {
            var Vendedores = _VendedoresService.GetVendedores();
            return Ok(Vendedores);
        }
    }
}
