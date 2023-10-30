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
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

         [HttpPost("realizar-venta")]
    public async Task<ActionResult<Venta>> RealizarVenta(string usuarioId)
    {
        var venta = await _ventaService.RealizarVenta(usuarioId);
        return Ok(venta);
        // Devolver respuesta adecuada
    }

    [HttpGet("obtener-venta/{ventaId}")]
    public async Task<ActionResult<Venta>> ObtenerVenta(int ventaId)
    {
        var venta = await _ventaService.ObtenerVenta(ventaId);
        return Ok(venta);
        // Devolver respuesta adecuada
    }
    }
}