using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
	public class Denuncia
	{
		public int Id { get; set; }
		public string NroDenuncia { get; set; }		
		public string EstadoDenuncia { get; set; }
		public string Tipo { get; set; }		
		public int IdCaso { get; set; }
		public int IdDenunciante { get; set; }

		public Denuncia(int id, string nroDenuncia, string estadoDenuncia, string tipo, int idCaso, int idDenunciante)
		{
			Id = id;
			NroDenuncia = nroDenuncia;
			
			EstadoDenuncia = estadoDenuncia;
			Tipo = tipo;
			IdCaso = idCaso;
			IdDenunciante = idDenunciante;
		}
		public Denuncia(string nroDenuncia, string estadoDenuncia, string tipo,int idDenunciante,int idCaso)
		{
			NroDenuncia = nroDenuncia;
			
			EstadoDenuncia = estadoDenuncia;
			Tipo = tipo;
			IdDenunciante = idDenunciante;
			IdCaso = idCaso;
		}     
    }
}
