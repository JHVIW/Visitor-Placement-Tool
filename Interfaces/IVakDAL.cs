using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IVakDAL
    {
        void CreateVak(Vak vak);
        Vak GetVakById(int id);
        IEnumerable<Vak> GetAllVakkenByEvenementId(int evenementId);
        void UpdateVak(Vak vak);
        void DeleteVak(int id);
    }
}
