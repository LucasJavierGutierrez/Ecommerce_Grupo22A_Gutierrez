using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Administracion_web
{
    public partial class listaCategorias : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminacion = false;
            tipoNegocio negocio = new tipoNegocio();
            dgvlistaCategoria.DataSource = negocio.listar();
            dgvlistaCategoria.DataBind();
        }

        protected void dgvlistaCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvlistaCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarTipo.aspx?Id="+id, false);

        }

        protected void dgvlistaCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idSeleccionado = int.Parse(dgvlistaCategoria.DataKeys[index]["Id"].ToString());
            Session.Add("idCategoriaEliminar", idSeleccionado);
            confirmaEliminacion = true;

        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    tipoNegocio negocioTipo = new tipoNegocio();
                    int idSeleccionado = int.Parse(Session["idCategoriaEliminar"].ToString());
    

                    ColoresXproductoNegocio negocio = new ColoresXproductoNegocio();
                    List<ColoresXproducto> lista = negocio.listarL();

                    foreach (var item in lista)
                    {


                        if (item.Producto.Tipo.Id == idSeleccionado || item.Producto.Tipo == null)
                        {
                            if (item.Stock == 0)
                            {
                                negocioTipo.eliminarConSP(idSeleccionado);
                                Response.Redirect("listaCategorias.aspx");

                                break;
                            }
                            else
                            {
                                Session.Add("Error", "No se ha podido eliminar la categoria, ya que aún cuenta con stock");
                                Response.Redirect("Error.aspx", false);

                                break;
                            }

                        }

                    }

                }
            }
            catch (Exception)
            {

                //Session.Add("Error", "No se ha podido actualizar los prodcuto");
                //Response.Redirect("Error.aspx", false);
            }
        }
    }
}