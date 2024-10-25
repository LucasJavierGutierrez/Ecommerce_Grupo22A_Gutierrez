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
    public partial class detalleProducto : System.Web.UI.Page
    {
        public Producto prod = new Producto();
        public Color colorSeleccionado = new Color();
        public int idColor = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                productoNegocio productoNegocio = new productoNegocio();
                List<Producto> list = new List<Producto>();
                list = productoNegocio.listar();
                int idSeleccionado = int.Parse(Request.QueryString["Id"]);

                prod = list.Find(x => x.Id == idSeleccionado);
                colorNegocio negocioColor = new colorNegocio();
                if (!IsPostBack)
                {
                    
                    List<Color> listColor = negocioColor.listar(idSeleccionado);
                    ddlColores.DataSource = listColor;
                    ddlColores.DataValueField = "Id";
                    ddlColores.DataTextField = "Nombre";
                    ddlColores.DataBind();

                }
            }

            catch (Exception)
            {

                Response.Redirect("Error.aspx", false);
            }

        }


        protected void ddlColores_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                colorNegocio negocio = new colorNegocio();
                List<Color> lista = negocio.listarTodos();

                idColor = int.Parse(ddlColores.SelectedItem.Value);
                colorSeleccionado = lista.Find(x => x.Id == idColor);
                if (idColor != 0 || idColor != null)
                {

                    ColoresXproductoNegocio cxpNegocio = new ColoresXproductoNegocio();
                    List<ColoresXproducto> listacxp = cxpNegocio.listarTodo();
                    ColoresXproducto cxp = listacxp.Find(x => x.Producto.Id == prod.Id && x.Color.Id == idColor);

                    lblStockDisponible.Text = "Hay " + cxp.Stock.ToString() + " Productos en stock";
                }
            }
            catch (Exception)
            {

                Session.Add("Error", "Recuerde seleccionar un color correcto!");
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void ddlColores_DataBound(object sender, EventArgs e)
        {
            ddlColores.Items.Insert(0, "--Seleccione un color--");

        }
    }
}