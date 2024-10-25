using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public Marca Marca { get; set; }
        public int? MemoriaInterna { get; set; }
        public int? MemoriaRam { get; set; }
        public string  Procesador { get; set; }
        public string TipoDisco { get; set; } //HDD O SSD
        public string SistemaOperativo{ get; set; }
        public string PlacaVideo { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public string Imagen4 { get; set; }
        public decimal Precio { get; set; }
       public bool Estado { get; set; }
    }
}
