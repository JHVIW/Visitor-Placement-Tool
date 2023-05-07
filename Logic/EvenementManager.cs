using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Logic
{
    public class EvenementManager
    {
        private readonly IEvenementDAL _evenementDAL;

        public EvenementManager(IEvenementDAL evenementDAL)
        {
            _evenementDAL = evenementDAL;
        }

        // Implementeer de methoden die de IEvenementDAL interface aanroept
    }
}
