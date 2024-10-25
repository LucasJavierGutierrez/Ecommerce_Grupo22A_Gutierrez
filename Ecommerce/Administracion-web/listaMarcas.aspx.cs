using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class listaMarcas : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminacion = false;
            marcaNegocio negocio = new marcaNegocio();
            dgvListaMarcas.DataSource = negocio.listar();
            dgvListaMarcas.DataBind();
        }

        protected void dgvListaMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idSeleccionado = dgvListaMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarMarca.aspx?Id=" + idSeleccionado, false);
       
        }

        protected void dgvListaMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            int idSeleccionado = int.Parse(dgvListaMarcas.DataKeys[index]["Id"].ToString());
            Session.Add("idMarcaEliminar", idSeleccionado);
   ///         string value = dgvListaMarcas.DataKeys[index]["Id"].ToString(); // Esto captura el ID de la marca seleccionada en ELIMINAR
              
                confirmaEliminacion = true;
            


        }


        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    int idSeleccionado = int.Parse(Session["idMarcaEliminar"].ToString());
                    marcaNegocio negocioMarca = new marcaNegocio();

          


                    ColoresXproductoNegocio negocio = new ColoresXproductoNegocio();
                    List<ColoresXproducto> lista = negocio.listarL();

                    bool hayStock = false;
                    foreach (var item in lista)
                    {


                        if (item.Producto.Marca.Id == idSeleccionado || item.Producto.Marca == null)
                        {
                            if (item.Stock == 0)
                            {
                                negocioMarca.eliminarConSP(idSeleccionado);
                                Response.Redirect("listaMarcas.aspx");

                                break;
                            }
                                
                            else
                            {
                                Session.Add("Error", "No se ha podido eliminar la marca ya que aún cuenta con stock");
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