using dominio;
using negocio;
using System;

namespace Administracion_web
{
    public partial class misComprasDetalle_ : System.Web.UI.Page
    {
        public TipoUsuario tu;
        public string idVentaXparametro; 
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else if (Request.QueryString["IdCompraDetalle"] == null)
            {
                Session.Add("Error", "Recuerde seleccionar un producto");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                tu = usuario.TipoUsuario;
                    string idVenta = Request.QueryString["IdCompraDetalle"].ToString();
                    idVentaXparametro = Request.QueryString["IdCompraDetalle"].ToString(); ;
                    CompraNegocio negocio = new CompraNegocio();
                    dgvDetalleCompra.DataSource = negocio.listarXVenta(idVenta);
                    dgvDetalleCompra.DataBind();
                

            }

        }
    }
}