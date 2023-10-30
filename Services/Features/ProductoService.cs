using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using nuevapicobro.Domain.Entities;

namespace nuevapicobro.Services.Features
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetProductoById(int id);
        Task<Producto> CreateProducto(Producto producto);
        Task<bool> UpdateProducto(int id, Producto producto);
        Task<bool> DeleteProducto(int id);
    }
    public class ProductoService 
    {
        private readonly DbPayUsContext _context;

        public ProductoService(DbPayUsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            return _context.Productos.ToList();
            //CREO QUE LO QUE HA ESTADO HACIENDO ES DARME LA LISTA DE PRODCUTOS EN FORMATO DE LISTA
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return _context.Productos.FirstOrDefault(x => x.Id == id);
            //CREO QUE LO QUE HA ESTADO HACIENDO ES DARME EL PRODUCTO CON EL ID QUE LE HE PASADO
        }
        // public async Task<Producto> CreateProducto(Producto producto)
        // {
        //     // Lógica para crear un nuevo producto
        // }

        // public async Task<bool> UpdateProducto(int id, Producto producto)
        // {
        //     // Lógica para actualizar un producto existente
        // }

        // public async Task<bool> DeleteProducto(int id)
        // {
        //     // Lógica para eliminar un producto por su ID
        // }

        // CON ESTO NO ESTOY DEL TODO SEGURO QUE SE USEN PERO AQUI TE LOS DEJO POR SI ACASOO


    }
}