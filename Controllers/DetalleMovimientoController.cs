using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using Microsoft.AspNetCore.JsonPatch.Internal;
using System.Collections.Generic;

namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class DetalleMovimientoController : ControllerBase
    {
        private readonly DetalleMovimientoService _DetalleMovimientoService;

        public DetalleMovimientoController(DetalleMovimientoService detalleMovimientoService)
        {
            _DetalleMovimientoService = detalleMovimientoService;

        }
        [HttpPost("Insert")]
        public JsonResult InsertDetalleMovimientos([FromBody] InsertDetalleMovimientoModel detalleMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                // Llamada al servicio para ejecutar el procedimiento almacenado
                var response = _DetalleMovimientoService.InsertDetalleMovimiento(detalleMovimiento);

                string msgDefault = "Movimiento Exitoso.";

                if (msgDefault == response)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = response
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = response
                    };
                }
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
        public IActionResult GetDetalleMovimiento([FromQuery] int id_Movimientos)
        {
            var articulo = _DetalleMovimientoService.GetDetalleMovimiento(id_Movimientos);
            return Ok(articulo);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetalleMovimiento([FromBody] UpdateDetalleMovimientoModel detalleMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleMovimientoService.UpdateDetalleMovimiento(detalleMovimiento);

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

        [HttpPut("Delete")]
        public JsonResult DeleteDetalleMovimiento([FromBody] DeleteDetalleMovimientoModel detalleMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleMovimientoService.DeleteDetalleMovimiento(detalleMovimiento);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro eliminado con exito";

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