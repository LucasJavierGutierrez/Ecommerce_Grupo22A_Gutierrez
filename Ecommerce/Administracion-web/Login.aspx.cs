using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace administracion_web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

        }


        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            try
            {

                if (txtEmail.Text != "" || txtPassword.Text != "")
                {
                    Usuario usuario;
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    usuario = usuarioNegocio.listar().Find(x => x.Email == txtEmail.Text && x.Contraseña == txtPassword.Text);
                    if (usuario != null)
                    {
                        if (usuarioNegocio.Loguear(usuario))
                        {
                            Session.Add("Usuario", usuario);
                            Session.Add("NombreUsuario", usuario.Nombre);
                            Response.Redirect("Default.aspx", false);
                            //    Session.Add("emailParametro", txtEmail.Text);

                        }
                    }
                    else
                    {
                        Session.Add("Error", "Email o contraseña incorrecta");
                        Response.Redirect("ErrorLogin.aspx", false);
                    }


                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("ErrorLogin.aspx", false);

            }

        }
    }
}