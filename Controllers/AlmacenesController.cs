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
    public class AlmacenesController : ControllerBase
    {
        private readonly AlmacenesService _almacenesService;

        public AlmacenesController(AlmacenesService almacenesservice)
        {
            _almacenesService = almacenesservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertAlmacen([FromBody] InsertAlmacenesModel almacen)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _almacenesService.InsertAlmacenes(almacen);

                if (almacen.Nombre != "" && almacen.Direccion != "" && almacen.Encargado != 0)
                {


                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Registro insertado con exito";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {

                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = false;
                    objectResponse.message = "Rellena todos los campos";

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



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetAlmacenes()
        {
            var almacen = _almacenesService.GetAlmacenes();
            return Ok(almacen);
        }


        [HttpPut("Update")]
        public JsonResult UpdateAlmacen([FromBody] UpdateAlmacenesModel almacen)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _almacenesService.UpdateAlmacenes(almacen);

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
        public JsonResult DeleteAlmacen([FromBody] DeleteAlmacenesModel almacen)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _almacenesService.DeleteAlmacenes(almacen);

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