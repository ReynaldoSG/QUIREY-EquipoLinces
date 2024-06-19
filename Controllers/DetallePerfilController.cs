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
    public class DetallePerfilController: ControllerBase
    {
        private readonly DetallePerfilService _DetallePerfilService;

    public DetallePerfilController(DetallePerfilService DetallePerfilService) 
    {
            _DetallePerfilService = DetallePerfilService;

    }
        [HttpPost("Insert")]
        public JsonResult InsertDetallePerfils([FromBody] InsertDetallePerfilModel DetallePerfil)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetallePerfilService.InsertDetallePerfil(DetallePerfil);
                
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
        public IActionResult GetDetallePerfil()
        {
            var articulo = _DetallePerfilService.GetDetallePerfil();
            return Ok(articulo);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetallePerfil([FromBody] UpdateDetallePerfilModel DetallePerfil)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetallePerfilService.UpdateDetallePerfil(DetallePerfil);
                
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
        public JsonResult DeleteDetallePerfil([FromBody] DeleteDetallePerfilModel DetallePerfil)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetallePerfilService.DeleteDetallePerfil(DetallePerfil);
                
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