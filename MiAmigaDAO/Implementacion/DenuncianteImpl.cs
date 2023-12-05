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
	public class DenuncianteImpl : BaseImpl, IDenunciante
	{
		public int Delete(Denunciante t)
		{
			throw new NotImplementedException();
		}

		public Denunciante Get(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Denunciante t)
		{
			throw new NotImplementedException();
		}
		public void Insert3(Persona p,Denunciante d, User t)
		{
			query = @"INSERT INTO Persona(nombre,primerApellido,segundoApellido,ci,direccion,telefono,genero,fechaNacimiento)
                    VALUES(@nombre,@primerApellido,@segundoApellido,@ci,@direccion,@telefono,@genero,@fechaNacimiento)";

			string query2 = @"INSERT INTO Usuario(idPersona,nombreUsuario,correo,contrasenia,rol)
                            VALUES (@idPersona,@nombreUsuario,@correo,HASHBYTES('MD5' ,@contrasenia),@rol)";

			string query3 = @"INSERT INTO Denunciante(idPersona,codDenunciante)
							VALUES(@idPersona,@codDenunciante)";
			List<SqlCommand> commands = Create3BasicCommand(query, query2, query3);
			commands[0].Parameters.AddWithValue("@nombre", p.Nombre);
			commands[0].Parameters.AddWithValue("@primerApellido", p.PrimerApellido);
			commands[0].Parameters.AddWithValue("@segundoApellido", p.SegundoApellido);
			commands[0].Parameters.AddWithValue("@ci", p.Ci);
			commands[0].Parameters.AddWithValue("@direccion", p.Direccion);
			commands[0].Parameters.AddWithValue("@telefono", p.Telefono);
			commands[0].Parameters.AddWithValue("@genero", p.Genero);
			commands[0].Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);

			int id = int.Parse(GetGenerateIDTable("Persona"));

			commands[1].Parameters.AddWithValue("@idPersona", id);
			commands[1].Parameters.AddWithValue("@nombreUsuario", t.NombreUsuario);
			commands[1].Parameters.AddWithValue("@correo", t.Correo);
			commands[1].Parameters.AddWithValue("@contrasenia", t.Contrasenia).SqlDbType = SqlDbType.VarChar;
			commands[1].Parameters.AddWithValue("@rol", t.Rol);

			commands[2].Parameters.AddWithValue("@idPersona", id);
			commands[2].Parameters.AddWithValue("@codDenunciante", d.CodDenunciante);
			ExecuteNBasicCommand(commands);
		}

		public DataTable Select()
		{
			query = @"SELECT P.id, P.nombre AS Nombre, P.primerApellido AS 'Primer Apellido', P.segundoApellido AS 'Segundo Apellido', P.ci AS CI, P.direccion AS Direccion , P.telefono AS Telefono, P.genero AS Genero, P.fechaNacimiento AS 'Fecha de Nacimiento', U.nombreUsuario AS Usuario, U.correo AS Correo, U.rol AS Rol, S.codDenunciante AS 'Codigo del Denunciante', S.fechaRegistro AS 'Fecha de registro'
                    FROM Persona P
                    INNER JOIN Denunciante S ON P.id = S.idPersona
                    INNER JOIN Usuario U ON P.id = U.idPersona
                    WHERE P.estado = 1";
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

		public int Update(Denunciante t)
		{
			throw new NotImplementedException();
		}

		public DataTable MostrarDenunciantes()
		{
			query = @"SELECT
					ISNULL(D.idPersona,0) idPersona,
					P.nombre AS 'Nombre',
					P.primerApellido AS 'Primer apellido',
					P.segundoApellido AS 'Segundo apellido',
					P.ci AS 'Carnet de identidad',
					P.genero AS 'Genero',	
					 FORMAT(P.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
				FROM Denunciante D
				RIGHT JOIN
					Persona P ON D.idPersona = P.id
				WHERE
					P.estado = 1 AND D.idPersona <> 0";
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
        public DataTable MostrarDenunciantesImprimir()
        {
            query = @"SELECT					
					P.nombre AS 'Nombre',
					P.primerApellido AS 'Primer apellido',
					P.segundoApellido AS 'Segundo apellido',
					P.ci AS 'Carnet de identidad',
					P.genero AS 'Genero',	
					 FORMAT(P.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
				FROM Denunciante D
				RIGHT JOIN
					Persona P ON D.idPersona = P.id
				WHERE
					P.estado = 1 AND ISNULL(D.idPersona,0) <> 0";
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
    }
}
