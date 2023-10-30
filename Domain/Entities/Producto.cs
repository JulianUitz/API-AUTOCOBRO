using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace nuevapicobro.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int? Cantidad { get; set; }
        [JsonIgnore]

        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; } = new List<CarritoProducto>();
        [JsonIgnore]

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
        
    }
}