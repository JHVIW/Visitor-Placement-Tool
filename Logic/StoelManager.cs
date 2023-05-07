using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Logic
{
    public class StoelManager
    {
        private readonly IStoelDAL _stoelDAL;

        public StoelManager(IStoelDAL stoelDAL)
        {
            _stoelDAL = stoelDAL;
        }

        // Implementeer de methoden die de IStoelDAL interface aanroept
    }
}
