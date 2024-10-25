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
    
    public partial class modificaTipo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Id"]!=null &&  !IsPostBack)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                tipoNegocio tipoNegocio = new tipoNegocio();
                Tipo tipo = (tipoNegocio.listar()).Find(x=> x.Id == id);
                txtNombre.Text = tipo.Nombre;


            }
            

            

        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            Tipo nuevo = new Tipo();
            nuevo.Nombre = txtNombre.Text;
            tipoNegocio negocioTipo = new tipoNegocio();
            if (Request.QueryString["Id"]== null)
            {
            negocioTipo.agregar(nuevo);
            Response.Redirect("listaCategorias.aspx", false);

            }
            else
            {
                int id = int.Parse(Request.QueryString["Id"]);
                negocioTipo.ModificarSP(id, nuevo);
                Response.Redirect("listaCategorias.aspx", false);

            }



        }
    }
}