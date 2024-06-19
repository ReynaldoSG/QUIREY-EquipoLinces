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
    [ApiController]
    public class ModUserController : ControllerBase
    {
        private readonly ModUsuarioService _modUserService;

        public ModUserController(ModUsuarioService modUsuarioService)
        {
            _modUserService = modUsuarioService;
        }

        [HttpPost("Insert")]
        public IActionResult InsertModUser([FromBody] InsertModUserModel modUser)
        {
            try
            {
                _modUserService.InsertModUser(modUser);

                return Ok(new
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    success = true,
                    message = "Registro insertado con éxito"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    message = "Error al insertar el registro"
                });
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetModUser()
        {
            try
            {
                var modUsers = _modUserService.GetModUser();
                return Ok(new
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    success = true,
                    message = "Registros obtenidos correctamente",
                    data = modUsers
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    message = "Error al obtener los registros"
                });
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateModUser([FromBody] UpdateModUserModel modUser)
        {
            try
            {
                _modUserService.UpdateModUser(modUser);

                return Ok(new
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    success = true,
                    message = "Registro actualizado con éxito"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    message = "Error al actualizar el registro"
                });
            }
        }

        [HttpPut("Delete")]
        public IActionResult DeleteModUser([FromBody] DeleteModUserModel modUser)
        {
            try
            {
                _modUserService.DeleteModUser(modUser);

                return Ok(new
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    success = true,
                    message = "Registro eliminado con éxito"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    message = "Error al eliminar el registro"
                });
            }
        }
    }
}