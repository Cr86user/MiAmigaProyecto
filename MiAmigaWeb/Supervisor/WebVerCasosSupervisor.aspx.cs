using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.MonthCalendar;

namespace MiAmigaWeb.Supervisor
{
    public partial class WebVerCasosSupervisor : System.Web.UI.Page
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
                LoadType();
            }
        }
      
       
        private void Select()
        {
          
                implSupervisor = new SupervisorImpl();
                id = int.Parse(Request.QueryString["id"]);
                DataTable dt = implSupervisor.SelectCasosSupervisor(id);
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
                        dr["Denunciante"].ToString(),"");
                }

                GridData.DataSource = table;
                GridData.DataBind();

                for (int i = 0; i < GridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["Id"].ToString();                 
                    GridData.Rows[i].Attributes["data-id"] = id;
                string Aceptar = $"<a class='btn btn-sm btn-warning' href='WebVerCaso.aspx?id={id}&type=U' target='_blank'>Ver ubicacion</a>";
                GridData.Rows[i].Cells[7].Text = Aceptar;
                }
        }
        private void LoadType()
        {
            type = Request.QueryString["type"];
            if (type == "U")
            {              
                ActualizarEstadoCaso();
                Select();
            }
        }
        private void ActualizarEstadoCaso()
        {

            id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                implCaso = new CasoImpl();
               
                int n = implCaso.UpdateEstadoCaso(id);
                if (n > 0)
                {
                    Response.Redirect("WebVerCasosCerrados.aspx");
                }
            }
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebMenuSupervisor.aspx");
        }
    }
}