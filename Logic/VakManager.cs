using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Logic
{
    public class VakManager
    {
        private readonly IVakDAL _vakDAL;

        public VakManager(IVakDAL vakDAL)
        {
            _vakDAL = vakDAL;
        }

        // Implementeer de methoden die de IVakDAL interface aanroept
    }
}
