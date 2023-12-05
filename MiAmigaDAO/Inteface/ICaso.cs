using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Inteface
{
    internal interface ICaso: IBase<Caso>
    {
        Caso Get(int id);
        void GetDate();
    }
}
