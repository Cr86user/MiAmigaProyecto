using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb.Administrador
{
    public partial class CrudSupervisorAdmin : System.Web.UI.Page
    {
        Persona p;
       MiAmigaDAO.Model.Supervisor s;
        User u;
        SupervisorImpl implSupervisor;
        byte id;
        string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
            Select();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string codigoSupervisor = CrearCodigo();
            try
            {
                Persona p = new Persona(txt_nombre.Text, txt_primerApellido.Text, txt_segundoApellido.Text, txt_ci.Text, txt_direccion.Text, txt_telefono.Text, char.Parse(ddl_genero.Text), DateTime.Parse(txt_fechaCumple.Text));
                MiAmigaDAO.Model.Supervisor s = new MiAmigaDAO.Model.Supervisor(codigoSupervisor, "Disponible");
                User u = new User(txt_nombreUsuario.Text, txt_correo.Text, txt_contrasenia.Text, "Supervisor");

                SupervisorImpl supervisorImpl = new SupervisorImpl();
                supervisorImpl.Insert3(p, s, u);
                Select();

            }
            catch (Exception)
            {

                throw;
            }
        }
        void Select()
        {
            implSupervisor = new SupervisorImpl();
            DataTable dt = implSupervisor.Select();

            DataTable table = new DataTable("Supervisor");

            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Primer Apellido", typeof(string));
            table.Columns.Add("Segundo Apellido", typeof(string));
            table.Columns.Add("CI", typeof(string));
            table.Columns.Add("Direccion", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("Genero", typeof(string));
            table.Columns.Add("Fecha de Nacimiento", typeof(string));
            table.Columns.Add("Usuario", typeof(string));
            table.Columns.Add("Correo", typeof(string));
            table.Columns.Add("Rol", typeof(string));
            table.Columns.Add("Codigo de Supervisor", typeof(string));
            table.Columns.Add("Estado", typeof(string));
            table.Columns.Add("Fecha de Registro", typeof(string));


            foreach (DataRow dr in dt.Rows)
            {
                table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString());
            }
            gridData.DataSource = table;
            gridData.DataBind();
            for (int i = 0; i < gridData.Rows.Count; i++)
            {
                string id = dt.Rows[i][0].ToString();



                gridData.Rows[i].Attributes["data-id"] = id;
            }


        }
        void load()
        {
            try
            {
                string type = Request.QueryString["type"];
                if (type == "D")
                {
                    Select();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        string CrearCodigo()
        {
            string primerApellido = txt_primerApellido.Text.Trim();
            string segundoApellido = txt_segundoApellido.Text.Trim();
            string email = txt_correo.Text.Trim();
            string nombre = txt_nombre.Text.Trim();
            string rol = "Supervisor";

            string inicialApellidoPaternoMinuscula = primerApellido.Substring(0, 1).ToLower();
            string inicialApellidoMaternoMinuscula = segundoApellido.Substring(0, 1).ToLower();
            string nombreCompletoSinEspacios = Regex.Replace(nombre, @"\s", "").ToLower();

            string user = inicialApellidoPaternoMinuscula + inicialApellidoMaternoMinuscula + nombreCompletoSinEspacios;

            return user;
        }
    }
}