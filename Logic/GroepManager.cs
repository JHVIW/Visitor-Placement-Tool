using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace Logic
{
    public class GroepManager
    {
        private readonly IGroepDAL _groepDAL;

        public GroepManager(IGroepDAL groepDAL)
        {
            _groepDAL = groepDAL;
        }

        // Implementeer de methoden die de IGroepDAL interface aanroept
    }
}
