using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class Usuario
    {
        public string NumeroTelefono { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}