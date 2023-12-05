using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
	public class Denunciante: Persona
	{
		public string CodDenunciante {  get; set; }
		public Denunciante(int id, string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento, byte imagen, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion, string codDenunciante)
					   : base(nombre, primerApellido, segundoApellido, ci, direccion, telefono, genero, fechaNacimiento, imagen, estado, fechaRegistro, fechaActualizacion)
		{
			CodDenunciante = codDenunciante;
		}
		public Denunciante(string codDenunciante) 
		{
			CodDenunciante = codDenunciante;
		}
	}
}
