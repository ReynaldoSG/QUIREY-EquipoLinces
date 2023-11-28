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
    public class RutasController: ControllerBase
    {
        private readonly RutasService _rutasService;

    public RutasController(RutasService rutasservice) 
    {
            _rutasService = rutasservice;
    }

        

        

        [HttpPost("Insert")]
        public JsonResult InsertRutas([FromBody] InsertRutasModel rutas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _rutasService.InsertRutas(rutas);
                
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



        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")] 
        public IActionResult GetRutas()
        {
            var rutas = _rutasService.GetRutas();
            return Ok(rutas);
        }

        
        [HttpPut("Update")]
        public JsonResult UpdateRutas([FromBody] UpdateRutasModel rutas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _rutasService.UpdateRutas(rutas);
                
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

        [HttpDelete("Delete")]
        public JsonResult DeleteRutas([FromQuery] DeleteRutasModel rutas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _rutasService.DeleteRutas(rutas);
                
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