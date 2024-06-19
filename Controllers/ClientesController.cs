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
    public class ClientesController: ControllerBase
    {
        private readonly ClientesService _clientesService;

    public ClientesController(ClientesService clientesservice) 
    {
            _clientesService = clientesservice;
    }

        

        

        [HttpPost("Insert")]
        public JsonResult InsertClientes([FromBody] InsertClientesModel cliente)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _clientesService.InsertClientes(cliente);
                
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
        public IActionResult GetClientes()
        {
            var cliente = _clientesService.GetClientes();
            return Ok(cliente);
        }

        
        [HttpPut("Update")]
        public JsonResult UpdateClientes([FromBody] UpdateClientesModel cliente)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _clientesService.UpdateClientes(cliente);
                
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
        public JsonResult DeleteClientes([FromBody] DeleteClientesModel cliente)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _clientesService.DeleteClientes(cliente);
                
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