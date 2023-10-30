using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class CarritoProducto
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito Carrito { get; set; }

        public virtual Producto Producto { get; set; }

    }
}