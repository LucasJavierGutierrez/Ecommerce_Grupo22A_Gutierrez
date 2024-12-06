using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class agregarOrificios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrificiosNegocio negocio = new OrificiosNegocio();
            dgvOrificios.DataSource = negocio.listarTodos();
            dgvOrificios.DataBind();

        }

        protected void dgvOrificios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvOrificios.SelectedDataKey.Value.ToString();
            Response.Redirect("stock.aspx?Id=" + id);
        }
    }
}