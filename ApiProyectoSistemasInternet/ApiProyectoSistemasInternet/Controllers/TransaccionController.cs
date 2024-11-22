using ApiProyectoSistemasInternet.IServices;
using ApiProyectoSistemasInternet.ModelsFarmaciaBD;
using ApiProyectoSistemasInternet.Repositories;
using ApiProyectoSistemasInternet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiProyectoSistemasInternet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionRepository _repository = new TransaccionRepository();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                bool token = Jwt.ValidateToken(identity);

                if (!token)
                {
                    return Unauthorized(new
                    {
                        statusCode = 401,
                        isExitoso = false,
                        errorMessages = new List<object> { "Error al autenticar." }
                    });
                }

                var response = _repository.GetObjectById(id);

                if (!response.isExitoso || response.resultado == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = response.errorMessages ?? new List<object> { "Transacción no encontrada." }
                    });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { "Error interno del servidor.", ex.Message }
                });
            }
        }

        [HttpPost]
        public IActionResult UpdateCreateTransaccion([FromBody] Transaccion transaccion)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                bool token = Jwt.ValidateToken(identity);

                if (!token)
                {
                    return Unauthorized(new
                    {
                        statusCode = 401,
                        isExitoso = false,
                        errorMessages = new List<object> { "Error al autenticar al usuario." }
                    });
                }

                var response = _repository.UpdateCreateObject(transaccion);

                if (response.isExitoso)
                {
                    if (response.statusCode == 201)
                    {
                        return CreatedAtAction(nameof(GetById), new { id = response.resultado.IdTransaccion }, response.resultado);
                    }
                    else if (response.statusCode == 200)
                    {
                        return Ok(response.resultado);
                    }
                }

                return StatusCode(response.statusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { "Error interno del servidor.", ex.Message }
                });
            }
        }

        [HttpGet("transacciones")]
        public IActionResult GetAllObjects([FromQuery] int offSet, [FromQuery] int pageSize)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                bool token = Jwt.ValidateToken(identity);

                if (!token)
                {
                    return Unauthorized(new
                    {
                        statusCode = 401,
                        isExitoso = false,
                        errorMessages = new List<object> { "Error al autenticar." }
                    });
                }

                var response = _repository.GetAllObjects(offSet, pageSize);

                if (response.isExitoso)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(response.statusCode, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GetAllResponse<Transaccion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { "Hubo un error al procesar la solicitud.", ex.Message }
                });
            }
        }

        [HttpDelete("transacciones/{id}")]
        public IActionResult DeleteObject(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                bool token = Jwt.ValidateToken(identity);

                if (!token)
                {
                    return Unauthorized(new
                    {
                        statusCode = 401,
                        isExitoso = false,
                        errorMessages = new List<object> { "Error al autenticar." }
                    });
                }

                var result = _repository.DeleteObject(id);

                if (result)
                {
                    return StatusCode(200, new GetAllResponse<Transaccion>
                    {
                        statusCode = 200,
                        isExitoso = true,
                        errorMessages = new List<object> { }
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        isExitoso = false,
                        errorMessages = new List<object> { "Transacción no encontrada." }
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GetAllResponse<Transaccion>
                {
                    statusCode = 500,
                    isExitoso = false,
                    errorMessages = new List<object> { "Hubo un error al procesar la solicitud.", ex.Message }
                });
            }
        }
    }

}
