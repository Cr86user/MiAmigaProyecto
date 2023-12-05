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
	public partial class CrudDenuncia : System.Web.UI.Page
	{
		DenunciaImpl implDenuncia;
		private static Random random = new Random();
		private string codigoAleatorio = GenerarCodigoAlAzar(8);
		static int id;
		protected void Page_Load(object sender, EventArgs e)
		{

				id = int.Parse(Session["id"].ToString());
				txtCodigo.Text = codigoAleatorio;
				load();
				Select();
				listaDenuncia();



        }      		
		protected void btnDenunciar_Click(object sender, EventArgs e)
		{
			string estado = "Pendiente";
			
				Denuncia d = new Denuncia(txtCodigo.Text, txtLatitud.Text, txtLongitud.Text, estado, ddlTipoDenuncia.Text,id,int.Parse(ddlCasos.Text));
				DenunciaImpl denunciaImpl = new DenunciaImpl();
				denunciaImpl.Insert(d);
				Select();
			
			
		}
        void listaDenuncia()
        {
            DenunciaImpl tp = new DenunciaImpl();
            DataTable tableCaso = new DataTable();

            tableCaso = tp.listaCasos();

			ddlCasos.DataTextField = "descripcion";
			ddlCasos.DataValueField = "id";
			ddlCasos.DataBind();

            ddlCasos.Items.Insert(0, new ListItem("Seleccione a que Caso Asociar esta denuncia", ""));

        }
        void Select()
		{
			try
			{
				implDenuncia = new DenunciaImpl();
				DataTable dt = implDenuncia.Select();

				DataTable table = new DataTable("Denuncia");
				table.Columns.Add("Numero de Denuncia", typeof(string));
				table.Columns.Add("Latitud", typeof(string));
				table.Columns.Add("Longitud", typeof(string));
				table.Columns.Add("Estado de la Denuncia", typeof(string));
				table.Columns.Add("Tipo de denuncia", typeof(string));
				table.Columns.Add("Hora y fecha de la denuncia", typeof(string));
				table.Columns.Add("Caso de la denuncia", typeof(string));
				table.Columns.Add("Codigo del denunciante", typeof(string));

				table.Columns.Add("Editar", typeof(string));
				table.Columns.Add("Eliminar", typeof(string));
				foreach (DataRow dr in dt.Rows)
				{
					table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
				}
				gridData.DataSource = table;
				gridData.DataBind();
				for (int i = 0; i < gridData.Rows.Count; i++)
				{
					string id = dt.Rows[i][0].ToString();
					string up = " <a class='btn btn-sm btn-info' href='UpdateCaso.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
					string del = " <a class='btn btn-sm btn-danger' href='WebReporte.aspx?id=" + id + "&type=D' onclick='return ConfirmDelete();'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a> ";



					gridData.Rows[i].Cells[8].Text = up;
					gridData.Rows[i].Cells[9].Text = del;
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

		public static string GenerarCodigoAlAzar(int longitud)
		{
			const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			char[] codigo = new char[longitud];

			for (int i = 0; i < longitud; i++)
			{
				codigo[i] = caracteres[random.Next(caracteres.Length)];
			}

			return new string(codigo);
		}

		protected void btnObtenerUbicacion_Click(object sender, EventArgs e)
		{
			try
			{
				// Lógica del lado del servidor al hacer clic en el botón
				string latitud = txtLatitud.Text;
				string longitud = txtLongitud.Text;
				// Realiza acciones con las coordenadas obtenidas, si es necesario.
			}
			catch (Exception ex)
			{
				// Manejar excepciones, si es necesario.
				// Por ejemplo, mostrar un mensaje de error.
				Response.Write("Error: " + ex.Message);
			}
		}
	}
}