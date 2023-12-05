using MiAmigaDAO.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb
{
	public partial class WebAdministrador : System.Web.UI.Page
	{
        CasoImpl implCaso;
		protected void Page_Load(object sender, EventArgs e)
		{
            Select();
            load();
		}
        void Select()
        {
            try
            {
                implCaso = new CasoImpl();
                DataTable dt = implCaso.Select();

                DataTable table = new DataTable("Caso");
                table.Columns.Add("Caso Numero", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Audio", typeof(string));
                table.Columns.Add("Estado del caso", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se inicio", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se cerro", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se reaperturo", typeof(string));
                table.Columns.Add("Codigo del denunciante", typeof(string));
                table.Columns.Add("Codigo del supervisor", typeof(string));

                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                gridData.DataSource = table;
                gridData.DataBind();
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = $" <a class='btn btn-sm btn-info' href='UpdateCaso.aspx?id={id}&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='WebReporte.aspx?id=" + id + "&type=D' onclick='return ConfirmDelete();'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a> ";



                    gridData.Rows[i].Cells[10].Text = up;
                    gridData.Rows[i].Cells[11].Text = del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void load()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "D")
                {
                    //Delete();
                    Select();
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}