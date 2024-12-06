using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class stock : System.Web.UI.Page
    {
        public bool nuevoColor;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if(Request.QueryString["Id"] != null && !IsPostBack)
                {
                    int idColor = int.Parse(Request.QueryString["Id"]);
                    OrificiosNegocio negocioColor = new OrificiosNegocio();
                    List<Orificios> listaColor= negocioColor.listarTodos();
                    Orificios color = listaColor.Find(x => x.Id == idColor);
                    
                    int idProductoSeleccionado = (int)Session["IdProductoAgregado"];
                    productoNegocio negocioProducto = new productoNegocio();
                    List<Producto> listaProducto = negocioProducto.listar();
                    Producto pr = listaProducto.Find(x => x.Id == idProductoSeleccionado);

                    OrificiosXproductoNegocio stockNegocio = new OrificiosXproductoNegocio();
                    OrificiosXproducto cxp = (stockNegocio.listarTodo()).Find(x=> x.Producto.Id == idProductoSeleccionado && x.Orificios.Id == idColor);
                    if (cxp != null)
                    {
                        txtStock.Text = cxp.Stock.ToString();

                    }
                    else
                    {
                        txtStock.Text = "";
                    }


                }
            }
            catch (Exception)
            {

                Session.Add("Error", "recuerde seleccionar un producto/color");
            }

        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(Session["IdProductoAgregado"].ToString());
            productoNegocio prNegocio = new productoNegocio();
            List<Producto> listaProducto = prNegocio.listar();
            Producto pr = listaProducto.Find(x => x.Id == idProducto);
            int idColorParametro = int.Parse(Request.QueryString["Id"].ToString());
            OrificiosNegocio colorNegocio = new OrificiosNegocio();
            List<Orificios> listColor = colorNegocio.listarTodos();
            Orificios color = listColor.Find(x => x.Id == idColorParametro);

            int cantStock = int.Parse(txtStock.Text);
            OrificiosXproducto cxp = new OrificiosXproducto();
            cxp.Producto = pr;
            cxp.Orificios = color;
            cxp.Stock = int.Parse(txtStock.Text);
            OrificiosXproductoNegocio negColor = new OrificiosXproductoNegocio();
            OrificiosXproducto coloresXproductoencontrado = (negColor.listarTodo()).Find(X => X.Producto.Id == idProducto && X.Orificios.Id == idColorParametro);
            if (coloresXproductoencontrado == null)
            {
                negColor.agregarSP(cxp);

            }
            else
            {
                negColor.modificarSP(cxp);
            }

            Response.Redirect("agregarOrificios.aspx", false);
        }

        protected void btnSumarStock_Click(object sender, EventArgs e)
        {
            int cantStock = int.Parse(txtStock.Text);
            if (cantStock >= 0)
            {
                cantStock++;
                txtStock.Text = cantStock.ToString();

            }

        }

        protected void btnRestarStock_Click(object sender, EventArgs e)
        {
            int cantStock = int.Parse(txtStock.Text);
            if (cantStock > 0)
            {
                cantStock--;
                txtStock.Text = cantStock.ToString();

            }
        }
    }
}