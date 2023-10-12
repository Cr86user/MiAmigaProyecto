using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiAmigaDAO.Model;

namespace MiAmigaDAO.Inteface
{
    internal interface IUser : IBase<User>
    {
        DataTable Login(string username, string password);
    }
}
