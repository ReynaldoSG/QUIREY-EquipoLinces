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
    public class VendedoresController : ControllerBase
    {
        private readonly VendedoresService _VendedoresService;

        public VendedoresController(VendedoresService vendedoresService)
        {
            _VendedoresService = vendedoresService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetVendedores()
        {
            var Vendedores = _VendedoresService.GetVendedores();
            return Ok(Vendedores);
        }

        [HttpPost("Insert")]
        public JsonResult InsertVendedores([FromBody] InsertVendedoresModel vendedores)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _VendedoresService.InsertVendedores(vendedores);

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


        [HttpPut("Update")]
        public JsonResult UpdateVendedores([FromBody] UpdateVendedoresModel vendedores)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _VendedoresService.UpdateVendedores(vendedores);

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
        public JsonResult DeleteVendedores([FromQuery] DeleteVendedoresModel vededores)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _VendedoresService.DeleteVendedores(vededores);

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
