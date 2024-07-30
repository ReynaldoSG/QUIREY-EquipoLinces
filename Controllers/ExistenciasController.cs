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
    public class ExistenciasController : ControllerBase
    {
        private readonly ExistenciasService _existenciasService;

        public ExistenciasController(ExistenciasService existenciasservice)
        {
            _existenciasService = existenciasservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertExistencias([FromBody] InsertExistenciasModel existencia)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _existenciasService.InsertExistencias(existencia);

                string msgDefault = "Registro insertado con éxito.";

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



        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetExistencias(GetExistenciasFiltroModel existencia)
        {
            var existencias = _existenciasService.GetExistencias(existencia);
            return Ok(existencias);
        }
        // public JsonResult GetTicket([FromBody] GetTicketsFiltroModel ticket)
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try
        //     {
        //         var CatClienteResponse = _ticketsService.GetTickets(ticket);

        //         objectResponse.StatusCode = (int)HttpStatusCode.OK;
        //         objectResponse.success = true;
        //         objectResponse.message = "Registros encontrados con exito";

        //         objectResponse.response = new
        //         {
        //             data = CatClienteResponse
        //         };
        //     }
        //     catch (System.Exception ex)
        //     {
        //         Console.Write(ex.Message);
        //         throw;
        //     }


        //     return new JsonResult(objectResponse);

        // }

        [HttpPut("Update")]
        public JsonResult UpdateExistencia([FromBody] UpdateExistenciasModel existencia)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _existenciasService.UpdateExistencias(existencia);

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
        public JsonResult DeleteExistencias([FromBody] DeleteExistenciasModel existencia)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _existenciasService.DeleteExistencias(existencia);

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