using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Administracion_web
{
    public partial class ShopCompus : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listarCompus();
                Session.Add("listadoProductos", ListaProductos);
            }else
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listarCompusXFiltro(txtSearch.Text.ToString());
                Session.Add("listadoProductos", ListaProductos);
            }
        }

        protected void btnMenorAMayor_Click(object sender, EventArgs e)
        {
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarCompusXOrden(1);

        }

        protected void btnMayorAMenor_Click(object sender, EventArgs e)
        {
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarCompusXOrden(2);

        }

        protected void btnAZ_Click(object sender, EventArgs e)
        {
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarCompusXOrden(3);

        }

        protected void btnZA_Click(object sender, EventArgs e)
        {
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarCompusXOrden(4);
        }
    }
}