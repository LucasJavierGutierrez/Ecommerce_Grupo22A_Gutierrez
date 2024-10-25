using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace administracion_web
{
    public partial class creaCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            bool seEncontroEmail = false;
            List<Usuario> lista = usuarioNegocio.listar();

            foreach (Usuario item in lista)
            {
                if (txtEmail.Text.ToLower() == item.Email.ToLower()) seEncontroEmail = true;
            }


            try
            {
                if (!seEncontroEmail && txtEmail.Text != null && txtConstraseña.Text != null)
                {
                    usuario = new Usuario(txtEmail.Text, txtConstraseña.Text, false);
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Contraseña = txtConstraseña.Text;



                    int id = usuarioNegocio.AgregarUsuario(usuario);


                    Response.Redirect("Login.aspx", false);
                    EmailServices email = new EmailServices();
                    string msjAsunto = "Bienvenido/a " + txtNombre.Text + "!!!";
                    email.armarCorreoBienvenida(usuario.Email.ToString(), msjAsunto);
                    email.enviarEmail();

                }
                else
                {
                    lblEmailEncontrado.Text = "El email igresado ya se ha registrado.";
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }



        }


    }


}