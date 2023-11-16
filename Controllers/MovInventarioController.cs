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
    public class MovInventarioController: ControllerBase
    {
        private readonly MovInventarioService _movInventarioService;

    public MovInventarioController(MovInventarioService movinventarioservice) 
    {
            _movInventarioService = movinventarioservice;
    }




        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")] 
        public IActionResult GetMovInventario()
        {
            var MovInventario = _movInventarioService.GetMovInventario();
            return Ok(MovInventario);
        }


        

        

        
    }
}