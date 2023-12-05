using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb.Denunciante
{
    public partial class RealizarDenuncia : System.Web.UI.Page
    {
        DenunciaImpl implDenuncia;
        private static Random random = new Random();
        private string codigoAleatorio = GenerarCodigoAlAzar(8);
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Session["id"].ToString());
                txtCodigo.Text = codigoAleatorio;
                load();
               
                listaDenuncia();
            }
        }
        protected void btnDenunciar_Click(object sender, EventArgs e)
        {
            string estado = "Pendiente";

            Denuncia d = new Denuncia(txtCodigo.Text, estado, ddlTipoDenuncia.Text, id, int.Parse(ddlCasos.Text));
            DenunciaImpl denunciaImpl = new DenunciaImpl();
            denunciaImpl.Insert(d);        
        }
        void listaDenuncia()
        {
            DenunciaImpl tp = new DenunciaImpl();
            DataTable tableCaso = new DataTable();

            tableCaso = tp.listaCasos(id);

            ddlCasos.DataTextField = "descripcion";
            ddlCasos.DataValueField = "id";
            ddlCasos.DataSource = tableCaso;
            ddlCasos.DataBind();

            ddlCasos.Items.Insert(0, new ListItem("Seleccione un caso si no cree uno nuevo", ""));
        }      
        void load()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "D")
                {                              
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
