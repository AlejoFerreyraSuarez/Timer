﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_AlejoFerreyra
{
    class Program
    {
        static void Main(string[] args)
        {
            IncrementService service = new IncrementService();

            ServiceBase.Run(service);
        }
    }
}
