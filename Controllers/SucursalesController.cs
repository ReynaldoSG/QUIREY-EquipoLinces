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
    public class SucursalesController : ControllerBase
    {
        private readonly SucursalesService _sucursalesService;

        public SucursalesController(SucursalesService sucursalesservice)
        {
            _sucursalesService = sucursalesservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertSucursal([FromBody] InsertSucursalesModel sucursal)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _sucursalesService.InsertSucursales(sucursal);

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
        public IActionResult GetSucursales()
        {
            var sucursal = _sucursalesService.GetSucursales();
            return Ok(sucursal);
        }


        [HttpPut("Update")]
        public JsonResult UpdateSucursal([FromBody] UpdateSucursalesModel sucursal)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _sucursalesService.UpdateSucursales(sucursal);

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
        public JsonResult DeleteSucursal([FromBody] DeleteSucursalesModel sucursal)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _sucursalesService.DeleteSucursales(sucursal);

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