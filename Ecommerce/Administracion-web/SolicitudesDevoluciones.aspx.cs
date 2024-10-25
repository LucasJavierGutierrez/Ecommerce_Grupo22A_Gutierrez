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
    public partial class SolicitudesDevoluciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SolicitudDevolucionNegocio negocio = new SolicitudDevolucionNegocio();
            List<SolicitudDevolucion> lista = negocio.listaSolicitudes();
            dgvSolicitudesDeDevolucion.DataSource = lista;
            dgvSolicitudesDeDevolucion.DataBind();

        }



        protected void dgvSolicitudesDeDevolucion_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Boton1")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idSeleccionado = int.Parse(dgvSolicitudesDeDevolucion.DataKeys[index]["Id"].ToString());
                SolicitudDevolucionNegocio negocio = new SolicitudDevolucionNegocio();
                SolicitudDevolucion solicitud = negocio.listaSolicitudes().Find(x => x.Id == idSeleccionado);
                negocio.sumoStock(solicitud.producto.Id, solicitud.color.Id, solicitud.cantidad);
                negocio.DevolucionAceptada(idSeleccionado);
                negocio.ActualizaTablaCompra(solicitud.IdVenta, solicitud.producto.Id, solicitud.color.Id, solicitud.cantidad);
               

                Response.Redirect("misCompras.aspx", false);

            }
            else if (e.CommandName == "Boton2")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idSeleccionado = int.Parse(dgvSolicitudesDeDevolucion.DataKeys[index]["Id"].ToString());
                SolicitudDevolucionNegocio negocio = new SolicitudDevolucionNegocio();
                SolicitudDevolucion solicitud = negocio.listaSolicitudes().Find(x => x.Id == idSeleccionado);
                negocio.cancelarSolicitudDevolucion(solicitud);

                Response.Redirect("MisCompras.aspx", false);

            }


            


        }
    }
}