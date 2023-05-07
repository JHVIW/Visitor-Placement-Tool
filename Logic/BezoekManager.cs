using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Logic
{
    public class BezoekerManager
    {
        private readonly IBezoekerDAL _bezoekerDAL;

        public BezoekerManager(IBezoekerDAL bezoekerDAL)
        {
            _bezoekerDAL = bezoekerDAL;
        }

        // Implementeer de methoden die de IBezoekerDAL interface aanroept
    }
}
