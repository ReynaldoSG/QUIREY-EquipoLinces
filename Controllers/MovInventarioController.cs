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
         
         [HttpPost("Insert")]
        public JsonResult InsertMovInventario([FromBody] InsertMovimientoModels MovInv)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movInventarioService.InsertMovInventario(MovInv);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }
         [HttpPut("Update")]
        public JsonResult UpdateMovInventario([FromBody] UpdateMovimientoInvModel MovimientoInv)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movInventarioService.UpdateMovIntentario(MovimientoInv);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro modificado con éxito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        
        [HttpDelete("Delete")]
        public JsonResult DeleteMovInventario([FromBody] DeleteMovimientoInvModel MovimientoInv)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movInventarioService.DeleteMovInventario(MovimientoInv);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información eliminada con éxito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }





        

        

        
    }
}