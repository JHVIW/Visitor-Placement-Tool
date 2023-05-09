using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace Interfaces
{
    public interface IStoelDAL
    {
        void CreateStoel(Stoel stoel);
        Stoel GetStoelById(int id);
        IEnumerable<Stoel> GetAllStoelenByRijId(int rijId);
        void UpdateStoel(Stoel stoel);
        void DeleteStoel(int id);
    }
}
