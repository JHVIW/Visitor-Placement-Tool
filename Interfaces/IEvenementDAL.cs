using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IEvenementDAL
    {
        void CreateEvenement(Evenement evenement);
        Evenement GetEvenementById(int id);
        IEnumerable<Evenement> GetAllEvenementen();
        void UpdateEvenement(Evenement evenement);
        void DeleteEvenement(int id);
    }
}
