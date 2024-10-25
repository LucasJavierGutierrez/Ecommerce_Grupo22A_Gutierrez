using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public int cant;

        public string Logeado;
        public TipoUsuario tu;
        protected void Page_Load(object sender, EventArgs e)
        {
        

            if (Session["cantidadProductosCarrito"] == null) 
                cant = 0;
             else
                cant = (int)Session["cantidadProductosCarrito"];

        Usuario usuario = Session["Usuario"] != null ? (Usuario)Session["Usuario"] : null;
            if (usuario != null)
            {
                tu = usuario.TipoUsuario;
            }
            

            if (usuario == null)
            {
                Logeado = "Login";
            }
            else
            {
               Logeado = "Exit"; // CAMBIAR AL NOMBRE DEL CLIENTE DSP
  //             Logeado = (string)Session["NombreUsuario"];

            }
         }
    }
}