using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IGroepDAL
    {
        void CreateGroep(Groep groep);
        Groep GetGroepById(int id);
        IEnumerable<Groep> GetAllGroepenByEvenementId(int evenementId);
        void UpdateGroep(Groep groep);
        void DeleteGroep(int id);
    }
}
