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
                    colorNegocio negocioColor = new colorNegocio();
                    List<Color> listaColor= negocioColor.listarTodos();
                    Color color = listaColor.Find(x => x.Id == idColor);
                    
                    int idProductoSeleccionado = (int)Session["IdProductoAgregado"];
                    productoNegocio negocioProducto = new productoNegocio();
                    List<Producto> listaProducto = negocioProducto.listar();
                    Producto pr = listaProducto.Find(x => x.Id == idProductoSeleccionado);

                    ColoresXproductoNegocio stockNegocio = new ColoresXproductoNegocio();
                    ColoresXproducto cxp = (stockNegocio.listarTodo()).Find(x=> x.Producto.Id == idProductoSeleccionado && x.Color.Id == idColor);
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
            colorNegocio colorNegocio = new colorNegocio();
            List<Color> listColor = colorNegocio.listarTodos();
            Color color = listColor.Find(x => x.Id == idColorParametro);

            int cantStock = int.Parse(txtStock.Text);
            ColoresXproducto cxp = new ColoresXproducto();
            cxp.Producto = pr;
            cxp.Color = color;
            cxp.Stock = int.Parse(txtStock.Text);
            ColoresXproductoNegocio negColor = new ColoresXproductoNegocio();
            ColoresXproducto coloresXproductoencontrado = (negColor.listarTodo()).Find(X => X.Producto.Id == idProducto && X.Color.Id == idColorParametro);
            if (coloresXproductoencontrado == null)
            {
                negColor.agregarSP(cxp);

            }
            else
            {
                negColor.modificarSP(cxp);
            }

            Response.Redirect("agregarColores.aspx", false);
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