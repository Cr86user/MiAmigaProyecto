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
    public partial class WebVerCaso : System.Web.UI.Page
    {
        SupervisorImpl implSupervisor;
        MiAmigaDAO.Model.Supervisor s;
        private int id;
        private string type;
        CasoImpl implCaso;
        Caso c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                loadType();
                Select();
            }
        }
        void loadType()
        {
            try
            {
                string type = Request.QueryString["type"];
                if (type == "U")
                {
                    Get();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void Get()
        {
            try
            {
                if (!IsPostBack)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        implCaso = new CasoImpl();
                        c = implCaso.GetUbicacion(id);
                        txt_latitude.Text = c.Latitud;
                        txt_longitude.Text = c.Longitud;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Select()
        {

            implSupervisor = new SupervisorImpl();
            id = int.Parse(Request.QueryString["id"]);
            DataTable dt = implCaso.SelecDenunciantePorCaso(id);
            DataTable table = new DataTable("Caso");
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Primer apellido", typeof(string));
            table.Columns.Add("Segundo apellido", typeof(string));
            table.Columns.Add("Carnet de identidad", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("Direccion", typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                table.Rows.Add(
                    dr["Nombre"].ToString(),
                    dr["Primer apellido"].ToString(),
                    dr["Segundo apellido"].ToString(),
                    dr["Carnet de identidad"].ToString(),
                    dr["Telefono"].ToString(),
                    dr["Direccion"].ToString());                   
            }

            GridData.DataSource = table;
            GridData.DataBind();

            for (int i = 0; i < GridData.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                GridData.Rows[i].Attributes["data-id"] = id;                              
            }
        }
    }
}