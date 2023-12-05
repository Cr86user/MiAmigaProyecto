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

namespace MiAmigaWeb
{
	public partial class CrudDenunciante : System.Web.UI.Page
	{
		Persona p;
		Denunciante d;
		User u;
		DenuncianteImpl implDenunciante;
		byte id;
		string type;
		protected void Page_Load(object sender, EventArgs e)
		{
			load();
			Select();
		}

        protected void btnInsert_Click(object sender, EventArgs e)
        {
			string codigoDenunciante = CrearCodigo();
			try
			{
				Persona p = new Persona(txt_nombre.Text, txt_primerApellido.Text, txt_segundoApellido.Text, txt_ci.Text, txt_direccion.Text, txt_telefono.Text, char.Parse(ddl_genero.Text), DateTime.Parse(txt_fechaCumple.Text));
				Denunciante d = new Denunciante(codigoDenunciante);
				User u = new User(txt_nombreUsuario.Text, txt_correo.Text, txt_contrasenia.Text, "Denunciante");

				DenuncianteImpl denuncianteImpl = new DenuncianteImpl();
				denuncianteImpl.Insert3(p, d, u);
				Select();

			}
			catch (Exception)
			{

				throw;
			}


		}
		void Select()
		{

			implDenunciante = new DenuncianteImpl();
			DataTable dt = implDenunciante.Select();

			DataTable table = new DataTable("Denunciante");

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
			table.Columns.Add("Codigo de Denunciante", typeof(string));			
			table.Columns.Add("Fecha de Registro", typeof(string));

			table.Columns.Add("Editar", typeof(string));
			table.Columns.Add("Eliminar", typeof(string));
			foreach (DataRow dr in dt.Rows)
			{
				table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString());
			}
			gridData.DataSource = table;
			gridData.DataBind();
			for (int i = 0; i < gridData.Rows.Count; i++)
			{
				string id = dt.Rows[i][0].ToString();
				string up = $"<a class='btn btn-sm btn-warning' href='CrudNurse.aspx?id={id}&type=U'> Seleccionar</a>";
				string del = $"<a class='btn btn-sm btn-danger' href='CrudNurse.aspx?id={id}&type=D' onclick='return ConfirmDelete();'> <i class='fas fa-trash' style='background:#FF0000;'>Eliminar</i></a>";

				gridData.Rows[i].Cells[13].Text = up;
				gridData.Rows[i].Cells[14].Text += del;
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
					//lblError.Text = " no Nulooooooooooooo";
					//Delete();
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