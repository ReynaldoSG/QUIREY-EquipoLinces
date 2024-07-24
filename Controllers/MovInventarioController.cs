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
    public class MovInventarioController : ControllerBase
    {
        private readonly MovInventarioService _movInventarioService;

        public MovInventarioController(MovInventarioService movinventarioservice)
        {
            _movInventarioService = movinventarioservice;
        }




        //[Authorize(AuthenticationSchemes = "Bearer")]

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetMovInventario(GetMovInvFiltroModel movimiento)
        {
            var MovInventario = _movInventarioService.GetMovInventario(movimiento);
            return Ok(MovInventario);
        }

        [HttpPost("Insert")]
        public JsonResult InsertMovInventario([FromBody] InsertMovimientoModels MovInv)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var movModel = _movInventarioService.InsertMovInventario(MovInv);
                if (movModel.Count > 0)
                {
                    var Id = movModel[0].Id;
                    var Msg = movModel[0].Mensaje;

                    string msgDefault = "Movimiento exitoso.";

                    if (msgDefault == Msg)
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.OK;
                        objectResponse.success = true;
                        objectResponse.message = "Éxito.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                    else
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        objectResponse.success = true;
                        objectResponse.message = "Error.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error: No se devolvió ningún resultado.";

                    objectResponse.response = null;
                }
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

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
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


        [HttpPut("Delete")]
        public JsonResult DeleteMovInventario([FromBody] DeleteMovimientoInvModel MovimientoInv)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movInventarioService.DeleteMovInventario(MovimientoInv);

                string msgDefault = "Registro eliminado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
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










    }
}