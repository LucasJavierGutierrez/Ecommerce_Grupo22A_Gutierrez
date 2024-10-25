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
    public partial class Devoluciones : System.Web.UI.Page
    {

        public List<itemCarrito> listaCarrito;
        public int cantStockDisponible;



        public List<SolicitudDevolucion> ListaSolicitudDevoluciones;
        public listaTotalSolicitud carrito = new listaTotalSolicitud(); 


        protected void Page_Load(object sender, EventArgs e)

        {
            
            string idVenta = Request.QueryString["IdVenta"];

            List<Producto> listProductos = new List<Producto>();
            CompraNegocio negocio = new CompraNegocio();

            listaCarrito = negocio.listarXVenta(idVenta);

            foreach (var item in listaCarrito)
            {
                if (listProductos.Find(x => x.Id == item.item.Id) == null)
                {
                    listProductos.Add(item.item);
                }

            }
            if (!IsPostBack)
            {
                ddlProducto.DataSource = listProductos;
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataBind();
            }










        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            string idProducto = ddlProducto.SelectedValue.ToString();
            Session.Add("IdProductoSeleccionado", idProducto);
            ddlColor.Enabled = true;
            
            CompraNegocio compraNegocio = new CompraNegocio();

            string idVenta = Request.QueryString["IdVenta"];
            List<Color> listColor = compraNegocio.listaColoresXVentaXProducto(idVenta, idProducto);
            ddlColor.DataSource = listColor;
            ddlColor.DataValueField = "Id";
            ddlColor.DataTextField = "Nombre";
            ddlColor.DataBind();


        }

        protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idColor = ddlColor.SelectedValue.ToString();
            Session.Add("IdColorSeleccionado", idColor);
            txtCantidad.Enabled = true;




        }























        protected void ddlColor_DataBound(object sender, EventArgs e)
        {
            ddlColor.Items.Insert(0, "--Seleccione un color--");
        }

        protected void ddlProducto_DataBound(object sender, EventArgs e)
        {
            ddlProducto.Items.Insert(0, "--Seleccione un producto--");
        }

        protected void btnSumarProductoDevolucion_Click(object sender, EventArgs e)
        {

            string idProducto = (string)Session["IdProductoSeleccionado"];
            string idColor = (string)Session["IdColorSeleccionado"];
            CompraNegocio negocio = new CompraNegocio();

            listaCarrito = negocio.listarXVenta(Request.QueryString["IdVenta"]);
            if (idProducto != null && idColor != null)
            {
                cantStockDisponible = listaCarrito.Find(x => x.item.Id.ToString() == idProducto && x.color.Id.ToString() == idColor).cantidad;
                if (int.Parse(txtCantidad.Text) > cantStockDisponible)
                {
                    lblErrorCantidadStock.Text = "Compraste " + cantStockDisponible + " Productos!!";
                }
            }

            if (int.Parse(txtCantidad.Text) <= cantStockDisponible && cantStockDisponible >0){
                
                //creo Variables para completar la solicitud 
                productoNegocio prNegocio = new productoNegocio();
                Producto pr = prNegocio.listar().Find(x => x.Id.ToString() == (string)Session["IdProductoSeleccionado"]);
                colorNegocio cNegocio = new colorNegocio();
                Color color = cNegocio.listarTodos().Find(x => x.Id.ToString() == (string)Session["IdColorSeleccionado"]);
                Usuario usuario = (Usuario)Session["Usuario"];


                ListaSolicitudDevoluciones = (List<SolicitudDevolucion>)Session["listaEnCarro"];
                carrito = (listaTotalSolicitud)Session["total"];

                if (ListaSolicitudDevoluciones == null)
                    ListaSolicitudDevoluciones = new List<SolicitudDevolucion>();

                if (carrito == null)
                {

                    carrito = new listaTotalSolicitud();
                }


                if ((string)Session["IdProductoSeleccionado"] != null && (string)Session["IdColorSeleccionado"]!= null)
                {
                    SolicitudDevolucion solicitudDevolucion = new SolicitudDevolucion();
                    string idVenta = Request.QueryString["IdVenta"];
                    solicitudDevolucion.IdVenta = int.Parse(idVenta);
                    solicitudDevolucion.producto = pr;
                    solicitudDevolucion.cantidad = int.Parse(txtCantidad.Text);
                    solicitudDevolucion.color = color;
                    solicitudDevolucion.motivo = txtMotivo.Text;
                    solicitudDevolucion.usuario = usuario;

                    ListaSolicitudDevoluciones.Add(solicitudDevolucion);
                    carrito.listado = ListaSolicitudDevoluciones;

                }
                tabla_productos.DataSource = ListaSolicitudDevoluciones;
                tabla_productos.DataBind();
                Session.Add("listaEnCarro", ListaSolicitudDevoluciones);
                Session.Add("total", carrito);

            }


            txtMotivo.Text = "";
        }

        protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {

            carrito = (listaTotalSolicitud)Session["total"];
            ListaSolicitudDevoluciones = (List<SolicitudDevolucion>)Session["listaEnCarro"];
            if (carrito.listado.Count() > 0)
            {
                
                SolicitudDevolucionNegocio negocioDevoluciones = new SolicitudDevolucionNegocio();
                foreach (var item in carrito.listado)
                {
                    negocioDevoluciones.agregarSolicitud(item);

                }
                carrito.listado.RemoveAll(i => i.IdVenta != 0);
                ListaSolicitudDevoluciones.RemoveAll(i => i.IdVenta != 0);
                Response.Redirect("MisCompras.aspx", false);
            }
            else
            {
                lblSinProductosLista.Text = "No has registrado ningun producto!";
            }




        }

        protected void btnEliminarProductoLista_Click(object sender, EventArgs e)
        {
            try
            {

                carrito = (listaTotalSolicitud)Session["total"];
                //int idEliminarProductoLista = int.Parse(((Button)sender).CommandArgument);
                string[] argument = ((Button)sender).CommandArgument.Split(',');
                int firstValue = Convert.ToInt32(argument[0]);
                int secondValue = Convert.ToInt32(argument[1]);

                List<SolicitudDevolucion> listDevoluciones = (List<SolicitudDevolucion>)Session["listaEnCarro"];
                SolicitudDevolucion elim = listDevoluciones.Find(x => x.color.Id == secondValue && x.producto.Id == firstValue);

                listDevoluciones.Remove(elim);
                Session.Add("listaEnCarro", listDevoluciones);
                Session.Add("total", carrito);
                tabla_productos.DataSource = null;
                tabla_productos.DataSource = listDevoluciones;
                tabla_productos.DataBind();






            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}