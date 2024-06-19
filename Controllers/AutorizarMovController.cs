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
    public class AutorizarMovController : ControllerBase
    {
        private readonly AutorizarMovService _autorizarmovService;

        public AutorizarMovController(AutorizarMovService autorizarmovservice)
        {
            _autorizarmovService = autorizarmovservice;
        }



        [Authorize(AuthenticationSchemes = "Bearer")]


        [HttpPut("Update")]
        public JsonResult AutorizarMov([FromBody] AutorizarMovModel autorizarmov)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _autorizarmovService.AutorizarMovInv(autorizarmov);

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