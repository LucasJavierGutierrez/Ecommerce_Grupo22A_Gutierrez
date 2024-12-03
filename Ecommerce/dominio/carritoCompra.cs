using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    //IDUSUARIO         No => Lo ingreso cuando se realice el LogIn  por el momento uso siempre idusuario=1

    public class carritoCompra
    {
        public int Id { get; set; }
        public List<itemCarrito> listado { get; set; }
        public Usuario usuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal total { get; set; }

    }
    public class itemCarrito
    {
        public int id { get; set; }
        public Producto item { get; set; }
        public Orificios Orificios { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}
