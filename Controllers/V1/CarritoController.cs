using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nuevapicobro.Domain.Entities;
using nuevapicobro.Services.Features;



namespace nuevapicobro.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;

        }
        [HttpGet("productos-en-carrito/{carritoId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosEnCarrito(int carritoId)
        {
            var productosEnCarrito = await _carritoService.GetProductosEnCarrito(carritoId);
            return Ok(productosEnCarrito);
            //no debe de estar bien
            // Devolver respuesta adecuada
        }

        [HttpPost("agregar-producto/{usuarioId}/{productoId}")]
        public async Task<ActionResult> AgregarProductoAlCarrito(string usuarioId, int productoId, int cantidad)
        {
            var resultado = await _carritoService.AgregarProductoAlCarrito(usuarioId, productoId, cantidad);
            return Ok(resultado);
            //tampoco debe de estar bien
            // Devolver respuesta adecuada
        }

        [HttpDelete("eliminar-producto/{carritoId}/{productoId}")]
        public async Task<ActionResult> EliminarProductoDelCarrito(int carritoId, int productoId)
        {

            var resultado = await _carritoService.EliminarProductoDelCarrito(carritoId, productoId);
            return Ok(resultado);
            //tampoco debe de estar bien
            // Devolver respuesta adecuada
        }
    }
}