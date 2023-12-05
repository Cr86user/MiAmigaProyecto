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
    public class SupervisorImpl : BaseImpl, ISupervisor
    {
        public int Delete(Supervisor t)
        {
            throw new NotImplementedException();
        }

        public Supervisor Get(byte id)
        {
            throw new NotImplementedException();
        }
        public Supervisor GetOcupacionSupervisor(int id)
        {
            Supervisor t = null;
            query = @"SELECT idPersona,ocupacion
                    FROM Supervisor
                    WHERE idPersona = @idPersona";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona",id);            
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    Supervisor caso = new Supervisor(
                        int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString()
                        );
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return t;
        }

        public int Insert(Supervisor t)
        {
            throw new NotImplementedException();
        }
        public DataTable SelectCasosSupervisor(int id)
        {
            query = @"SELECT C.id AS id, S.codSupervisor AS 'Supervisor',C.nro'Numero del caso', C.descripcion AS Descripcion, C.estadoCaso AS 'Estado del Caso', C.fechaInicio 'Fecha de Inicio', C.fechaActualizacion AS 'Fecha de Actualizacion', D.codDenunciante AS Denunciante
                    FROM Caso C
                    INNER JOIN Supervisor S ON C.idSupervisor = S.idPersona
                    INNER JOIN Denunciante D ON C.idDenunciante = D.idPersona
					INNER JOIN Persona P ON S.idPersona = P.id
					INNER JOIN Usuario U ON S.idPersona = U.idPersona
                    WHERE C.idSupervisor = @idSupervisor AND C.estadoCaso ='Abierto'";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idSupervisor", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable SelectCasosSupervisorCerrados(int id)
        {
            query = @"SELECT P.id, S.codSupervisor AS 'Supervisor',C.nro'Numero del caso', C.descripcion AS Descripcion, C.estadoCaso AS 'Estado del Caso', C.fechaInicio 'Fecha de Inicio', C.fechaActualizacion AS 'Fecha de Actualizacion', D.codDenunciante AS Denunciante
                    FROM Caso C
                    INNER JOIN Supervisor S ON C.idSupervisor = S.idPersona
                    INNER JOIN Denunciante D ON C.idDenunciante = D.idPersona
					INNER JOIN Persona P ON S.idPersona = P.id
					INNER JOIN Usuario U ON S.idPersona = U.idPersona
                    WHERE C.idSupervisor = @idSupervisor AND C.estadoCaso ='Cerrado'";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idSupervisor", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Insert3(Persona p, Supervisor s, User t)
        {
            query = @"INSERT INTO Persona(nombre,primerApellido,segundoApellido,ci,direccion,telefono,genero,fechaNacimiento)
                    VALUES(@nombre,@primerApellido,@segundoApellido,@ci,@direccion,@telefono,@genero,@fechaNacimiento)";

            string query2 = @"INSERT INTO Usuario(idPersona,nombreUsuario,correo,contrasenia,rol)
                            VALUES (@idPersona,@nombreUsuario,@correo,HASHBYTES('MD5' ,@contrasenia),@rol)";

            string query3 = @"INSERT INTO Supervisor(idPersona,codSupervisor,ocupacion)
                            VALUES (@idPersona,@codSupervisor,@ocupacion)";

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
            commands[2].Parameters.AddWithValue("@codSupervisor", s.CodSupervisor);
            commands[2].Parameters.AddWithValue("@ocupacion", s.Ocupacion);
            
                ExecuteNBasicCommand(commands);
            
           
        }
        public DataTable Select()
        {
            query = @"SELECT P.id, P.nombre AS Nombre, P.primerApellido AS 'Primer Apellido', P.segundoApellido AS 'Segundo Apellido', P.ci AS CI, P.direccion AS Direccion , P.telefono AS Telefono, P.genero AS Genero, P.fechaNacimiento AS 'Fecha de Nacimiento', U.nombreUsuario AS Usuario, U.correo AS Correo, U.rol AS Rol, S.codSupervisor AS 'Codigo del supervisor', S.ocupacion AS Disponibilidad, S.fechaRegistro AS 'Fecha de registro'
                    FROM Persona P
                    INNER JOIN Supervisor S ON P.id = S.idPersona
                    INNER JOIN Usuario U ON P.id = U.idPersona
                    WHERE P.estado = 1 ";

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
       
        public int Update(Supervisor t)
        {
            throw new NotImplementedException();
        }
        public DataTable MostrarSupervisores()
        {
            query = @"SELECT
	                ISNULL(S.idPersona,0) idPersona,
	                P.nombre AS 'Nombre',
	                P.primerApellido AS 'Primer apellido',
	                P.segundoApellido AS 'Segundo apellido',
	                P.ci AS 'Carnet de identidad',
	                P.genero AS 'Genero',
	                S.ocupacion AS 'Estado',
	                 FORMAT(P.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
                FROM Supervisor S
                RIGHT JOIN
	                Persona P ON S.idPersona = P.id
                WHERE
	                P.estado = 1 AND S.idPersona <> 0";
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
        public DataTable MostrarSupervisoresImprimir()
        {
            query = @"SELECT	               
	                P.nombre AS 'Nombre',
	                P.primerApellido AS 'Primer apellido',
	                P.segundoApellido AS 'Segundo apellido',
	                P.ci AS 'Carnet de identidad',
	                P.genero AS 'Genero',
	                S.ocupacion AS 'Estado',
	                 FORMAT(P.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
                FROM Supervisor S
                RIGHT JOIN
	                Persona P ON S.idPersona = P.id
                WHERE
	                P.estado = 1 AND ISNULL(S.idPersona,0) <> 0";
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
