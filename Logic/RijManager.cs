using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Logic
{
    public class RijManager
    {
        private readonly IRijDAL _rijDAL;

        public RijManager(IRijDAL rijDAL)
        {
            _rijDAL = rijDAL;
        }

        // Implementeer de methoden die de IRijDAL interface aanroept
    }
}
