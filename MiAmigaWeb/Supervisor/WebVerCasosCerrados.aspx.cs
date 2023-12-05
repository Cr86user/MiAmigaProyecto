using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb.Supervisor
{
    public partial class WebVerCasosCerrados : System.Web.UI.Page
    {
        SupervisorImpl implSupervisor;
        MiAmigaDAO.Model.Supervisor c;
        private int id;
        private string type;
        CasoImpl implCaso;
        Caso C;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                Select();               
            }
        }
        private void Select()
        {

            implSupervisor = new SupervisorImpl();
            id = int.Parse(Request.QueryString["id"]);
            DataTable dt = implSupervisor.SelectCasosSupervisorCerrados(id);
            DataTable table = new DataTable("Caso");
            table.Columns.Add("Supervisor", typeof(string));
            table.Columns.Add("Numero del Caso", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("Estado del caso", typeof(string));
            table.Columns.Add("Fecha de Inicio", typeof(string));
            table.Columns.Add("Fecha de Actualizacion", typeof(string));
            table.Columns.Add("Denunciante", typeof(string));
            table.Columns.Add("Seleccionar", typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                table.Rows.Add(
                    dr["Supervisor"].ToString(),
                    dr["Numero del caso"].ToString(),
                    dr["Descripcion"].ToString(),
                    dr["Estado del Caso"].ToString(),
                    dr["Fecha de Inicio"].ToString(),
                    dr["Fecha de Actualizacion"].ToString(),
                    dr["Denunciante"].ToString(), "");
            }

            GridData.DataSource = table;
            GridData.DataBind();

            for (int i = 0; i < GridData.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                GridData.Rows[i].Attributes["data-id"] = id;
                string Aceptar = $"<a class='btn btn-sm btn-warning' href='WebVerCasosCerrados.aspx?id={id}&type=U' target='_blank'>Aceptar Caso</a>";
                GridData.Rows[i].Cells[7].Text = Aceptar;
            }
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebMenuSupervisor.aspx");
        }
    }
}