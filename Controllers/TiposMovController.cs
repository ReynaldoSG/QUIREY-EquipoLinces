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
    public class TiposMovController : ControllerBase
    {
        private readonly TiposMovService _tiposmovService;

        public TiposMovController(TiposMovService tiposmovservice)
        {
            _tiposmovService = tiposmovservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertTiposMov([FromBody] InsertTiposMovModel tipomov)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _tiposmovService.InsertTiposMov(tipomov);

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
        public IActionResult GetTiposMov()
        {
            var articulo = _tiposmovService.GetTiposMov();
            return Ok(articulo);
        }


        [HttpPut("Update")]
        public JsonResult UpdateTiposMov([FromBody] UpdateTiposMovModel tiposmov)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _tiposmovService.UpdateTiposMov(tiposmov);

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
        public JsonResult DeleteTiposMov([FromBody] DeleteTiposMovModel tiposmov)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _tiposmovService.DeleteTiposMov(tiposmov);

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