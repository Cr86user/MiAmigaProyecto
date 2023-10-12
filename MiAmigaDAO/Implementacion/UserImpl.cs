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
        public DataTable Login(string username, string password)
        {
            throw new NotImplementedException();
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
