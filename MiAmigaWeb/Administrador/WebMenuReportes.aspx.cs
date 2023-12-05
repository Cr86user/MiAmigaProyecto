using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb.Administrador
{
    public partial class WebMenuReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes/WebGenerarReporte.aspx");
        }
        protected void btnGenerarReporteDenuncia_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes/WebGenerarReporteDenunciante.aspx");
        }
        protected void btnGenerarReporteSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes/WebGenerarReporteSupervisores.aspx");
        }
    }
}