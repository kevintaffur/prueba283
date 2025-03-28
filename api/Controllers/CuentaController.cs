using api.Dtos.Cuentas;
using api.Dtos.Productos;
using api.Models;
using api.Services;
using api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v1/cuentas")]
    public class CuentaController : ControllerBase
    {
        private ICuentaService Service;

        public CuentaController(ICuentaService service)
        {
            Service = service;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new Response
            {
                Status = 200,
                Message = "Cuentas obtenidas satisfactoriamente.",
                Content = await Service.ObtenerTodas()
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CuentaCreacionDto cuenta)
        {
            try
            {
                return Created("", new Response
                {
                    Status = 201,
                    Message = "Cuenta creada satisfactoriamente",
                    Content = await Service.Crear(cuenta)
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo crear la cuenta con los datos proporcionados.",
                    Content = null
                });
            }
        }

        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpPost("cambio-moneda/{id:int}")]
        public async Task<IActionResult> CambioDeMoneda([FromRoute] int id, [FromBody] CambioMonedaDto cambio)
        {
            Cuenta cuenta = await Service.CambioSaldoADestino(id, cambio.Moneda);

            if (cuenta == null)
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Cuenta no existe.",
                    Content = null
                });
            }

            try
            {
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Cuenta obtenida satisfactoriamente",
                    Content = cuenta
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo obtener la cuenta con los datos proporcionados.",
                    Content = null
                });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("calculo-interes/{id:int}")]
        public async Task<IActionResult> CalculoInteres([FromRoute] int id, [FromBody] InteresesDto intereses)
        {
            Cuenta cuenta = await Service.ObtenerPorId(id);

            if (cuenta == null)
            {
                return NotFound(new Response
                {
                    Status = 404,
                    Message = "Cuenta no existe.",
                    Content = null
                });
            }

            try
            {
                decimal interes = await Service.CalculoInteres(id, intereses.Dias);
                return Ok(new Response
                {
                    Status = 200,
                    Message = "Cuenta obtenida satisfactoriamente",
                    Content = new
                    {
                        cuenta,
                        interes
                    }
                });
            }
            catch
            {
                return BadRequest(new Response
                {
                    Status = 400,
                    Message = "No se pudo obtener la cuenta con los datos proporcionados.",
                    Content = null
                });
            }
        }

        //[Authorize(Roles = "admin")]
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Modificar([FromRoute] int id, [FromBody] CuentaModificacionDto cuenta)
        //{
        //    try
        //    {
        //        Cuenta cuentaExistente = await Service.Modificar(id, cuenta);

        //        if (cuentaExistente == null)
        //        {
        //            return NotFound(new Response
        //            {
        //                Status = 404,
        //                Message = "Cuenta no existe.",
        //                Content = null
        //            });
        //        }
        //        return Ok(new Response
        //        {
        //            Status = 200,
        //            Message = "Cuenta modificada de forma satisfactoria.",
        //            Content = cuentaExistente
        //        });
        //    }
        //    catch
        //    {
        //        return BadRequest(new Response
        //        {
        //            Status = 400,
        //            Message = "No se pudo modificar la cuenta con los datos proporcionados.",
        //            Content = null
        //        });
        //    }
        //}

        //[Authorize(Roles = "admin, user")]
        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> ObtenerPorId([FromRoute] int id)
        //{
        //    try
        //    {
        //        Cuenta cuenta = await Service.ObtenerPorId(id);

        //        if (cuenta == null)
        //        {
        //            return NotFound(new Response
        //            {
        //                Status = 404,
        //                Message = "Cuenta no existe",
        //                Content = null
        //            });
        //        }
        //        return Ok(new Response
        //        {
        //            Status = 200,
        //            Message = "Cuenta obtenida.",
        //            Content = cuenta
        //        });
        //    }
        //    catch
        //    {
        //        return NotFound(new Response
        //        {
        //            Status = 404,
        //            Message = "Cuenta no existe.",
        //            Content = null
        //        });
        //    }
        //}
    }
}
