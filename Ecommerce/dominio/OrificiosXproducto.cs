using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class OrificiosXproducto
    {
        public Producto Producto { get; set; }
        public Orificios Orificios { get; set; }
        public int Stock { get; set; }
    }
}
