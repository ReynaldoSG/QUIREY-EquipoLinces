using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Collections.Generic;
using System.Linq;
namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketsService _ticketsService;

        public TicketsController(TicketsService ticketsservice)
        {
            _ticketsService = ticketsservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertTicket([FromBody] InsertTicketsModel ticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var ticketModels = _ticketsService.InsertTickets(ticket);

                if (ticketModels.Count > 0)
                {
                    var Id = ticketModels[0].Id;
                    var Msg = ticketModels[0].Mensaje;

                    string msgDefault = "Registro insertado con éxito.";

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


        /*         [Authorize(AuthenticationSchemes = "Bearer")]
         */
        [HttpGet("Get")]
        public IActionResult GetTickets([FromQuery] GetTicketsFiltroModel ticket)
        {
            var tickets = _ticketsService.GetTickets(ticket);
            return Ok(tickets);
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
        public JsonResult UpdateTickets([FromBody] UpdateTicketsModel ticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _ticketsService.UpdateTickets(ticket);
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
        public JsonResult DeleteTickets([FromBody] DeleteTicketsModel tickets)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _ticketsService.DeleteTickets(tickets);
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

        [HttpGet("GetCorte")]
        public IActionResult GetCorte(GetCorteFiltroModel corte)
        {
            var cortes = _ticketsService.GetCorte(corte);
            return Ok(cortes);
        }









    }
}