using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public class listaTotalSolicitud
    {
        public List<SolicitudDevolucion> listado { get; set; }
    }
    public class SolicitudDevolucion
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public Producto producto { get; set; }
        public Color color { get; set; }
        public int cantidad { get; set; }
        public Usuario usuario { get; set; }
        public string motivo { get; set; }
        public bool devuelto { get; set; }
    }
}
