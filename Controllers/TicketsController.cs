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
                var CatClienteResponse = _ticketsService.InsertTickets(ticket);

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
        public IActionResult GetTickets([FromQuery] GetTicketsFiltroModel ticket)
        {
            var tickets = _ticketsService.GetTickets(ticket);
            return Ok(tickets);
        }

        [HttpPut("Update")]
        public JsonResult UpdateTickets([FromBody] UpdateTicketsModel ticket)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _ticketsService.UpdateTickets(ticket);

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

        [HttpPut("Delete")]
        public JsonResult DeleteTickets([FromBody] DeleteTicketsModel tickets)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _ticketsService.DeleteTickets(tickets);

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
