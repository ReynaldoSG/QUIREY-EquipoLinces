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
    public class PuestosController : ControllerBase
    {
        private readonly PuestosService _puestosService;

        public PuestosController(PuestosService puestosservice)
        {
            _puestosService = puestosservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertPuesto([FromBody] InsertPuestoModel puesto)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _puestosService.InsertPuestos(puesto);

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
        public IActionResult GetPuesto()
        {
            var puesto = _puestosService.GetPuestos();
            return Ok(puesto);
        }


        [HttpPut("Update")]
        public JsonResult UpdatePuesto([FromBody] UpdatePuestoModel puesto)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _puestosService.UpdatePuestos(puesto);

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

        [HttpPut("Delete")]
        public JsonResult DeletePuesto([FromBody] DeletePuestoModel puesto)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _puestosService.DeletePuesto(puesto);

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