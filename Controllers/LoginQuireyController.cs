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
    public class LoginQuireyController: ControllerBase
    {
        private readonly LoginQuireyService _LoginQuireyService;

    public LoginQuireyController(LoginQuireyService LoginQuireyService) 
    {
            _LoginQuireyService = LoginQuireyService;

    }
        [HttpPut("GetCatPerfil")]
        public JsonResult GetCatPerfil([FromBody] GetCatPerfilSearch LoginQuirey)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _LoginQuireyService.ListaModulosPerfil(LoginQuirey.IdPerfil);
                
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

        [HttpPut("GetModCat")]
        public JsonResult GetModCat([FromBody] GetModCatSearch Categoria)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _LoginQuireyService.GetModCat(Categoria.IdCategoria);
                
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
    }
}