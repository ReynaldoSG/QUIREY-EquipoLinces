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
    public class DetalleMapeosController: ControllerBase
    {
        private readonly MapeosService _mapeoService;
        private readonly ILogger<DetalleMapeosController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public DetalleMapeosController(MapeosService mapeoservice, ILogger<DetalleMapeosController> logger, IJwtAuthenticationService authService) {
            _mapeoService = mapeoservice;
            _logger = logger;
       
            _authService = authService;
        }

        

        

        [HttpPost("Insert")]
        public JsonResult InsertDetalleMapeo([FromBody] RenglonMapeoModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.InsertDetalleMapeo(mapeo);
                
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
        public JsonResult GetDetalleMapeo([FromQuery] GetDetalleMapeoreq mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetDetalleMapeo(mapeo.IdMapeo, mapeo.Tipo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con éxito";

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