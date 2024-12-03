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
        public Orificios colorSeleccionado = new Orificios();
        public int idOrificios = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                productoNegocio productoNegocio = new productoNegocio();
                List<Producto> list = new List<Producto>();
                list = productoNegocio.listar();
                int idSeleccionado = int.Parse(Request.QueryString["Id"]);

                prod = list.Find(x => x.Id == idSeleccionado);
                OrificiosNegocio negocioColor = new OrificiosNegocio();
                if (!IsPostBack)
                {
                    
                    List<Orificios> listColor = negocioColor.listar(idSeleccionado);
                    ddlOrificios.DataSource = listColor;
                    ddlOrificios.DataValueField = "Id";
                    ddlOrificios.DataTextField = "Nombre";
                    ddlOrificios.DataBind();

                }
            }

            catch (Exception)
            {

                Response.Redirect("Error.aspx", false);
            }

        }


        protected void ddlOrificios_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                OrificiosNegocio negocio = new OrificiosNegocio();
                List<Orificios> lista = negocio.listarTodos();

                idOrificios = int.Parse(ddlOrificios.SelectedItem.Value);
                colorSeleccionado = lista.Find(x => x.Id == idOrificios);
                if (idOrificios != 0 || idOrificios != null)
                {

                    OrificiosXproductoNegocio cxpNegocio = new OrificiosXproductoNegocio();
                    List<OrificiosXproducto> listacxp = cxpNegocio.listarTodo();
                    OrificiosXproducto cxp = listacxp.Find(x => x.Producto.Id == prod.Id && x.Orificios.Id == idOrificios);

                    lblStockDisponible.Text = "Hay " + cxp.Stock.ToString() + " Productos en stock";
                }
            }
            catch (Exception)
            {

                Session.Add("Error", "Recuerde seleccionar un color correcto!");
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void ddlOrificios_DataBound(object sender, EventArgs e)
        {
            ddlOrificios.Items.Insert(0, "--Seleccione un color--");

        }
    }
}