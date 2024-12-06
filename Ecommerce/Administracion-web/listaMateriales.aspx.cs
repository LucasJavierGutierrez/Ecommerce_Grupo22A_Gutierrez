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
    public partial class listaMateriales : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminacion = false;
            materialNegocio negocio = new materialNegocio();
            dgvListaMateriales.DataSource = negocio.listar();
            dgvListaMateriales.DataBind();
        }

        protected void dgvListaMateriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idSeleccionado = dgvListaMateriales.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarMaterial.aspx?Id=" + idSeleccionado, false);
       
        }

        protected void dgvListaMateriales_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            int idSeleccionado = int.Parse(dgvListaMateriales.DataKeys[index]["Id"].ToString());
            Session.Add("idMaterialEliminar", idSeleccionado);
   ///         string value = dgvListaMateriales.DataKeys[index]["Id"].ToString(); // Esto captura el ID de la Material seleccionada en ELIMINAR
              
                confirmaEliminacion = true;
            


        }


        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    int idSeleccionado = int.Parse(Session["idMaterialEliminar"].ToString());
                    materialNegocio NegocioMaterial = new materialNegocio();

          


                    OrificiosXproductoNegocio negocio = new OrificiosXproductoNegocio();
                    List<OrificiosXproducto> lista = negocio.listarL();

                    bool hayStock = false;
                    foreach (var item in lista)
                    {


                        if (item.Producto.Material.Id == idSeleccionado || item.Producto.Material == null)
                        {
                            if (item.Stock == 0)
                            {
                                NegocioMaterial.eliminarConSP(idSeleccionado);
                                Response.Redirect("ListaMateriales.aspx");

                                break;
                            }
                                
                            else
                            {
                                Session.Add("Error", "No se ha podido eliminar la Material ya que aún cuenta con stock");
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