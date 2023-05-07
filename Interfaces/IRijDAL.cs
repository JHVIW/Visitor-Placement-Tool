using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRijDAL
    {
        void CreateRij(Rij rij);
        Rij GetRijById(int id);
        IEnumerable<Rij> GetAllRijenByVakId(int vakId);
        void UpdateRij(Rij rij);
        void DeleteRij(int id);
    }
}
