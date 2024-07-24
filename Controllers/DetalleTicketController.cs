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
    public class DetalleTicketController : ControllerBase
    {
        private readonly DetalleTicketService _DetalleTicketService;

        public DetalleTicketController(DetalleTicketService detalleticketservice)
        {
            _DetalleTicketService = detalleticketservice;

        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleTickets([FromBody] InsertDetalleTicketModel detalleticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTicketService.InsertDetalleTicket(detalleticket);

                string msgDefault = "Venta realizada con éxito.";

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
        public IActionResult GetDetalleTicket(GetDetalleTicketSearchModel detalleticket)
        {
            var articulo = _DetalleTicketService.GetDetalleTicket(detalleticket);
            return Ok(articulo);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetalleTicket([FromBody] UpdateDetalleTicketModel detalleticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTicketService.UpdateDetalleTicket(detalleticket);

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
        public JsonResult DeleteDetalleTicket([FromBody] DeleteDetalleTicketModel detalleticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTicketService.DeleteDetalleTicket(detalleticket);

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

        [HttpPut("Autorizar")]
        public JsonResult AutorizarTicket([FromBody] AutorizarTicketModel autorizarticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTicketService.AutorizarTickets(autorizarticket);

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