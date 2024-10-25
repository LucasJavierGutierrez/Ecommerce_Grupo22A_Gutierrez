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

    public partial class modificaProducto : System.Web.UI.Page
    {
        public int idTipoSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                tipoNegocio negocioTipo = new tipoNegocio();
                ddlTipo.DataSource = negocioTipo.listar();
                ddlTipo.DataTextField = "NOMBRE";
                ddlTipo.DataValueField = "ID";
                ddlTipo.DataBind();

                marcaNegocio negocioMarca = new marcaNegocio();
                ddlMarca.DataSource = negocioMarca.listar();
                ddlMarca.DataTextField = "NOMBRE";
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataBind();
            }

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                productoNegocio negocio = new productoNegocio();
                Producto seleccionado = (negocio.listar(id))[0];

                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString();
                txtMemoriaInterna.Text = seleccionado.MemoriaInterna.ToString();
                txtMemoriaRam.Text = seleccionado.MemoriaRam.ToString();
                txtProcesador.Text = seleccionado.Procesador;
                txtImagenURL1.Text = seleccionado.Imagen1;
                txtImagenURL2.Text = seleccionado.Imagen2;
                txtImagenURL3.Text = seleccionado.Imagen3;
                txtImagenURL4.Text = seleccionado.Imagen4;

                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();


            }



        }



        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void dgvColores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (txtMemoriaRam.Text != "" && txtMemoriaInterna.Text != "")
            {
                Producto nuevo = new Producto();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Tipo = new Tipo();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                if (txtMemoriaInterna.Text == "" || txtMemoriaRam.Text == "")
                {
                    nuevo.MemoriaInterna = null;
                    nuevo.MemoriaRam = null;
                }
                else
                {
                    nuevo.MemoriaInterna = int.Parse(txtMemoriaInterna.Text);
                    nuevo.MemoriaRam = int.Parse(txtMemoriaRam.Text);
                }

                nuevo.Procesador = txtProcesador.Text.ToString();
                nuevo.TipoDisco = txtDisco.Text.ToString();
                nuevo.SistemaOperativo = txtSistemaOperativo.Text;
                nuevo.PlacaVideo = txtPlacaVideo.Text;
                nuevo.Imagen1 = txtImagenURL1.Text;
                nuevo.Imagen2 = txtImagenURL2.Text;
                nuevo.Imagen3 = txtImagenURL3.Text;
                nuevo.Imagen4 = txtImagenURL4.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                productoNegocio negocioProducto = new productoNegocio();

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocioProducto.modificarConSP(nuevo);
                    Session.Add("IdProductoAgregado", nuevo.Id); //mando por sesion el id del producto agregado
                    Response.Redirect("agregarColores.aspx", false); //Lo recibo en pesteña stock... Asi al agregar stock, tengo el numero del id de producto ya que por parametro mando el ID del color seleccionado


                }
                else
                {

                    negocioProducto.agregar(nuevo);
                    Producto pr = negocioProducto.listaProductoAgregado();
                    Session.Add("IdProductoAgregado", pr.Id); //mando por sesion el id del producto agregado
                    Response.Redirect("agregarColores.aspx", false); //Lo recibo en pesteña stock... Asi al agregar stock, tengo el numero del id de producto ya que por parametro mando el ID del color seleccionado


                }

            }





        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoSeleccionado = int.Parse(ddlTipo.SelectedItem.Value);
        }
    }
}