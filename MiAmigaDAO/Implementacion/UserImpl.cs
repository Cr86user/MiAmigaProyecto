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
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            throw new NotImplementedException();
        }
        public int Insert(User T)
        {
            throw new NotImplementedException();
        }
        public DataTable Login(string nombreUsuario, string contrasenia)
        {
            query = @"SELECT idPersona,nombreUsuario,rol
                    FROM Usuario
                    WHERE estado = 1 AND nombreUsuario = @nombreUsuario
                    AND contrasenia = HASHBYTES('MD5',@contrasenia)";
			SqlCommand command = CreateBasicCommand(query);
			command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
			command.Parameters.AddWithValue("@contrasenia", contrasenia).SqlDbType = SqlDbType.VarChar;
			try
			{
				return ExecuteDataTableCommand(command);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
