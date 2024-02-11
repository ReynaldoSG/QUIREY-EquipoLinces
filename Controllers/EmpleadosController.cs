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
    public class EmpleadosController: ControllerBase
    {
        private readonly EmpleadosService _empleadosService;

    public EmpleadosController(EmpleadosService empleadosservice) 
    {
            _empleadosService = empleadosservice;
    }

        

        

        [HttpPost("Insert")]
        public JsonResult InsertEmpleado([FromBody] InsertEmpleadosModel empleado)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _empleadosService.InsertEmpleado(empleado);
                
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
        public IActionResult GetEmpleados()
        {
            var empleado = _empleadosService.GetEmpleados();
            return Ok(empleado);
        }

        
        [HttpPut("Update")]
        public JsonResult UpdateEmpleado([FromBody] UpdateEmpleadosModel empleadosModel)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _empleadosService.UpdateEmpleados(empleadosModel);
                
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
        public JsonResult DeleteEmpleado([FromBody] DeleteEmpleadosModel empleadosModel)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _empleadosService.DeleteEmpleados(empleadosModel);
                
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