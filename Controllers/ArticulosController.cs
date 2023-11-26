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
    public class ArticulosController: ControllerBase
    {
        private readonly ArticulosService _articulosService;

    public ArticulosController(ArticulosService articulosservice) 
    {
            _articulosService = articulosservice;
    }

        

        

        [HttpPost("Insert")]
        public JsonResult InsertArticulo([FromBody] InsertArticulosModel articulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _articulosService.InsertArticulos(articulo);
                
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
        public IActionResult GetArticulos()
        {
            var articulo = _articulosService.GetArticulos();
            return Ok(articulo);
        }

        
        [HttpPut("Update")]
        public JsonResult UpdateArticulo([FromBody] UpdateArticulosModel articulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _articulosService.UpdateArticulos(articulo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información actualizada con éxito";

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
        public JsonResult DeleteArticulo([FromBody] DeleteArticulosModel articulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _articulosService.DeleteArticulos(articulo);
                
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