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
    
    public partial class modificaMaterial : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["Id"] != null && !IsPostBack)
            {
                materialNegocio negocioMaterial = new materialNegocio();
                int idSeleccionado = int.Parse(Request.QueryString["Id"]);
                Material Material = (negocioMaterial.listar()).Find(x => x.Id == idSeleccionado);
                txtNombre.Text = Material.Nombre;
            }
            

            

        }


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            Material nuevo = new Material();
            nuevo.Nombre = txtNombre.Text;
            materialNegocio negocioMaterial = new materialNegocio();
            if (Request.QueryString["Id"]== null)
            {
                negocioMaterial.agregar(nuevo);
                Response.Redirect("ListaMateriales.aspx", false);
            }else
            {
                int id = int.Parse(Request.QueryString["Id"]);
                negocioMaterial.ModificarSP(id, nuevo);
                Response.Redirect("ListaMateriales.aspx", false);
            }




        }

 
    }
}