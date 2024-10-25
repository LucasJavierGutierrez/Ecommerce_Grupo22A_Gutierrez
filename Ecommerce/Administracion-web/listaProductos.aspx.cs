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
    public partial class listaProductos : System.Web.UI.Page
    {

        public List<Producto> ListaProductos { get; set; }
        public TipoUsuario tu; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]!= null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                tu = usuario.TipoUsuario;
            }
            if (txtSearch.Text == "")
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listar();
                Session.Add("listadoProductosListaProductos", ListaProductos);
            }
            else
            {
                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listarConFiltro(txtSearch.Text.ToString());
                Session.Add("listadoProductosListaProductos", ListaProductos);
            }
            repetidor.DataSource = ListaProductos;
            repetidor.DataBind();

            if (!IsPostBack)
            {
                //repetidor.DataSource = ListaProductos;
                //repetidor.DataBind();
            }
        }

  

        protected void dgvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                productoNegocio negocioProducto = new productoNegocio();
                int idSeleccionado = int.Parse(((Button)sender).CommandArgument);
                ColoresXproductoNegocio negocioColores = new ColoresXproductoNegocio();
                int cantidadStock = negocioColores.sumaStockXProducto(idSeleccionado);
                if (cantidadStock == 0)
                {
                    negocioProducto.eliminarConSP(idSeleccionado);
                    Response.Redirect("listaProductos.aspx", false);
                }
                else
                {
                    Session.Add("Error", "No se ha podido eliminar la marca ya que aún cuenta con stock");
                    Response.Redirect("Error.aspx", false);

                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", "No se ha podido actualizar el producto");
                Response.Redirect("Error.aspx", false);

                throw;
            }
        }
    }
}