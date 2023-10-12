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

        public int Insert(Supervisor t)
        {
            throw new NotImplementedException();
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
            query = @"SELECT P.nombre, P.primerApellido, P.segundoApellido, P.ci, P.direccion, P.telefono, P.genero, P.fechaNacimiento, U.nombreUsuario, U.correo, U.rol, S.codSupervisor, S.ocupacion, S.fechaRegistro
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
    }
}
