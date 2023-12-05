using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Inteface
{
	internal interface IDenunciante :IBase<Denunciante>
	{
		Denunciante Get(int id);
	}
}
