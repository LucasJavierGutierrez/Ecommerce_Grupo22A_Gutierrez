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
    public partial class ShopTodos : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (txtSearch.Text == "")
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listar();
                Session.Add("listadoProductos", ListaProductos);
            } else
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listarConFiltro(txtSearch.Text.ToString());
                Session.Add("listadoProductos", ListaProductos);
            }
        }

        protected void btnMenorAMayor_Click(object sender, EventArgs e)
        {
            //1 
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltro(1);

        }

        protected void btnMayorAMenor_Click(object sender, EventArgs e)
        {
            //2
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltro(2);
        }

        protected void btnAZ_Click(object sender, EventArgs e)
        {
            //3
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltro(3);
        }

        protected void btnZA_Click(object sender, EventArgs e)
        {
            //4
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltro(4);

        }
    }
}