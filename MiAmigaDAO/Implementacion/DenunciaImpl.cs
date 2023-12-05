using MiAmigaDAO.Inteface;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Implementacion
{
	public class DenunciaImpl : BaseImpl, IDenuncia
	{
		public int Delete(Denuncia t)
		{
			throw new NotImplementedException();
		}

		public Denuncia Get(byte id)
		{
			throw new NotImplementedException();
		}
		
		public int Insert(Denuncia t)
		{
			query = @"INSERT INTO Denuncia(nroDenuncia,estadoDenuncia,tipo,idCaso,idDenunciante)
					VALUES(@nroDenuncia,@estadoDenuncia,@tipo,@idCaso,@idDenunciante)";
			SqlCommand command = CreateBasicCommand(query);
			command.Parameters.AddWithValue(@"nroDenuncia", t.NroDenuncia);			
			command.Parameters.AddWithValue(@"estadoDenuncia", t.EstadoDenuncia);
			command.Parameters.AddWithValue(@"tipo",t.Tipo);
			command.Parameters.AddWithValue(@"idCaso",t.IdCaso);
			command.Parameters.AddWithValue(@"idDenunciante", t.IdDenunciante);		
			try
			{
				return ExecuteBasicCommand(command);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public DataTable Select()
		{
			query = @"SELECT D.id, D.nroDenuncia AS 'Numero de Denuncia',D.estadoDenuncia AS 'Estado de la Denuncia',
					D.tipo AS 'Tipo de Denuncia', D.fechaDenuncia AS 'Hora y fecha de la denuncia', C.nro AS 'Caso de la Denuncia', DT.codDenunciante AS 'Codigo del denunciante' 
					FROM Denuncia D
					INNER JOIN Caso C ON D.idCaso = C.id
					INNER JOIN Denunciante DT ON DT.idPersona = D.idDenunciante
					WHERE D.estado = 1
					ORDER BY 2";
			SqlCommand command = CreateBasicCommand(query);
			try
			{
				return ExecuteDataTableCommand(command);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public int Update(Denuncia t)
		{
			throw new NotImplementedException();
		}
        public DataTable listaCasos(int id)
        {
            query = @"SELECT C.id AS id, C.descripcion AS descripcion
					FROM Caso C
					INNER JOIN Denunciante D ON D.idPersona = C.idDenunciante
					WHERE C.estado = 1 AND D.idPersona = @idPersona";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
