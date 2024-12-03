using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class agregarColores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrificiosNegocio negocio = new OrificiosNegocio();
            dgvColores.DataSource = negocio.listarTodos();
            dgvColores.DataBind();

        }

        protected void dgvColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvColores.SelectedDataKey.Value.ToString();
            Response.Redirect("stock.aspx?Id=" + id);
        }
    }
}