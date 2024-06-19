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
    public class UMController : ControllerBase
    {
        private readonly UMService _umService;

        public UMController(UMService umservice)
        {
            _umService = umservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertUM([FromBody] InsertUMModel um)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _umService.InsertUM(um);

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
        public IActionResult GetUM()
        {
            var um = _umService.GetUM();
            return Ok(um);
        }


        [HttpPut("Update")]
        public JsonResult UpdateUM([FromBody] UpdateUMModel um)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _umService.UpdateUM(um);

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
        public JsonResult DeleteUM([FromBody] DeleteUMModel um)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _umService.DeleteUM(um);

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