using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        Persona p;
       MiAmigaDAO.Model.Denunciante d;
        User u;
        DenuncianteImpl implDenunciante;
        byte id;
        string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44339/");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string codigoDenunciante = CrearCodigo();
            try
            {
                Persona p = new Persona(txt_nombre.Text, txt_primerApellido.Text, txt_segundoApellido.Text, txt_ci.Text, txt_direccion.Text, txt_telefono.Text, char.Parse(ddl_genero.Text), DateTime.Parse(txt_fechaCumple.Text));
                MiAmigaDAO.Model.Denunciante d = new MiAmigaDAO.Model.Denunciante(codigoDenunciante);
                User u = new User(txt_nombreUsuario.Text, txt_correo.Text, txt_contrasenia.Text, "Denunciante");

                DenuncianteImpl denuncianteImpl = new DenuncianteImpl();
                denuncianteImpl.Insert3(p, d, u);
                Response.Redirect("WebLogin.aspx");

            }
            catch (Exception)
            {

                throw;
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