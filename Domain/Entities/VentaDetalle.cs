using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class VentaDetalle
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}