using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb
{
    public partial class UpdateCaso : System.Web.UI.Page
    {
        SupervisorImpl implSupervisor;
        CasoImpl implCaso;
        Caso c;
        Supervisor s;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaSupervisor();
                id = int.Parse(Request.QueryString["id"]);
                LoadType();
            }
        }
        void LoadType()
        {
           
                type = Request.QueryString["type"];

                if (type == "U")
                {
                    Get();
                }
            
            
        }
        void Get()
        {
            c = null;
            id = int.Parse(Request.QueryString["id"]);

           
                implCaso = new CasoImpl();
                c = implCaso.GetSupervisor(id);
                if (c != null)
                {                 
                    ddlSupervisores.Text = c.IdSupervisor.ToString();
                }              

        }
        void listaSupervisor()
        {
            CasoImpl tp = new CasoImpl();
            DataTable tableSupervisor = new DataTable();

            tableSupervisor = tp.listaSupervisor();

            ddlSupervisores.DataTextField = "codSupervisor";
            ddlSupervisores.DataValueField = "idPersona";
            ddlSupervisores.DataSource = tableSupervisor;
            ddlSupervisores.DataBind();

            ddlSupervisores.Items.Insert(0, new ListItem("Seleccione un Supervisor", ""));
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id>0)
                {
                    implCaso = new CasoImpl();
                    Caso caso = new Caso(id,int.Parse(ddlSupervisores.Text));
                    int n = implCaso.UpdateSupervisor(caso);
                    int m = implCaso.UpdateOcupacion(caso);
                   
                    if (n>0 && m>0) 
                    {                       
                        Response.Redirect("WebAdministrador.aspx");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}