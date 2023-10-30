using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class Carrito
    {
        public int Id { get; set; }
        public string? UsuarioId { get; set; }

        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; } = new List<CarritoProducto>();

        public virtual Usuario? Usuario { get; set; }
    }
}