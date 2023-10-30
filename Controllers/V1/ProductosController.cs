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
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
          _productoService = productoService;
        }


        [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        var productos = await _productoService.GetAllProductos();
        return Ok(productos);
        //no debe de estar bien el return es solo para que marque ni un error
        // Devolver respuesta adecuada
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _productoService.GetProductoById(id);
        return Ok(producto);
        //igual lo mismio 
        // Devolver respuesta adecuada
    }

    // [HttpPost]
    // public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    // {
    //     var createdProducto = await _productoService.CreateProducto(producto);
    //     // Devolver respuesta adecuada
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutProducto(int id, Producto producto)
    // {
    //     var result = await _productoService.UpdateProducto(id, producto);
    //     // Devolver respuesta adecuada
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteProducto(int id)
    // {
    //     var result = await _productoService.DeleteProducto(id);
    //     // Devolver respuesta adecuada
    // }

    }
}