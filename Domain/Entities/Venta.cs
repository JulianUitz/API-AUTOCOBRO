using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public string? UsuarioId { get; set; }
        public decimal MontoTotal { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
        
    }
}