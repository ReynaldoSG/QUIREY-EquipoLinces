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
    public class EstadosController : ControllerBase
    {
        private readonly EstadosService _EstadosService;

        public EstadosController(EstadosService EstadosService)
        {
            _EstadosService = EstadosService;

        }
        [HttpPost("Insert")]
        public JsonResult InsertEstados([FromBody] InsertEstadosModel Estados)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _EstadosService.InsertEstados(Estados);

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



        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetEstados()
        {
            var articulo = _EstadosService.GetEstados();
            return Ok(articulo);
        }

        [HttpPut("Update")]
        public JsonResult UpdateEstados([FromBody] UpdateEstadosModel Estados)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _EstadosService.UpdateEstados(Estados);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro actualizado con exito";

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