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
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
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
                    int id = byte.Parse(table.Rows[0][0].ToString());
                    string name = table.Rows[0][1].ToString();
                    string role = table.Rows[0][2].ToString();

                    Session["id"] = id;
                    Session["name"] = name;
                    Session["role"] = role;

                    switch (table.Rows[0][2].ToString())
                    {
                        case "Administrador":
                            string url = "Default.aspx";
                            Response.Redirect(url);
                            break;
                        case "Supervisor":

                            string urrl = "DefaultCajero.aspx";
                            Response.Redirect(urrl);

                            break;
                        case "Usuario":
                            string urrrl = "DefaultChef.aspx";
                            Response.Redirect(urrrl);
                            break;
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