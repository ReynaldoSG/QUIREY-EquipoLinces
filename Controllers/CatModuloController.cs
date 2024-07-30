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
    public class CatModuloController : ControllerBase
    {
        private readonly CatModuloService _catModuloService;

        public CatModuloController(CatModuloService catmoduloservice)
        {
            _catModuloService = catmoduloservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertCatModulo([FromBody] InsertCatModuloModel catModulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _catModuloService.InsertCatModulo(catModulo);
                string msgDefault = "Registro insertado con éxito.";


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



/*         [Authorize(AuthenticationSchemes = "Bearer")]
 */        [HttpGet("Get")]
        public IActionResult GetCatModulo()
        {
            var catModulo = _catModuloService.GetCatModulo();
            return Ok(catModulo);
        }


        [HttpPut("Update")]
        public JsonResult UpdateCatModulo([FromBody] UpdateCatModuloModel catModulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _catModuloService.UpdateCatModulo(catModulo);
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
        public JsonResult DeleteCatModulo([FromBody] DeleteCatModuloModel catModulo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _catModuloService.DeleteCatModulo(catModulo);
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







    }
}