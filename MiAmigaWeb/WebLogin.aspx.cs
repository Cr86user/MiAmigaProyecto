using MiAmigaDAO.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MiAmigaWeb
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       
		protected void btnIngresar_Click1(object sender, EventArgs e)
		{
			Login();
		}
		void Login()
		{
			try
			{
				UserImpl implUser = new UserImpl();
				DataTable table = implUser.Login(txtLogin.Text, txtPassword.Text);
				if (table.Rows.Count > 0)
				{
					int id = int.Parse(table.Rows[0][0].ToString());
					string name = table.Rows[0][1].ToString();
					string role = table.Rows[0][2].ToString();

					Session["id"] = id;
					Session["name"] = name;
					Session["rol"] = role;

					switch (table.Rows[0][2].ToString())
					{
						case "Administrador":							
							Response.Redirect("Administrador/WebAdminAsignar.aspx");
							break;
						case "Supervisor":							
							Response.Redirect("Supervisor/WebMenuSupervisor.aspx");
							break;
                        case "Denunciante":
                            Response.Redirect("Denunciante/WebMenuDenunciante.aspx");                           
                            break;
                    }
				}
			}
           catch(Exception ex)
            {
				//MessageBox.Show("Errro de redireccionamiento" + ex.ToString());
			}
		}
	}
}