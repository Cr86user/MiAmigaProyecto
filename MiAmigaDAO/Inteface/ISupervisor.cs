﻿using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Inteface
{
    internal interface ISupervisor :IBase<Supervisor>
    {
        Supervisor Get(byte id);
    }
}
