using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace DAL
{
    public class RijDAL : IRijDAL
    {
        private readonly string _connectionString;

        public RijDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateRij(Rij rij)
        {
            // Implementeer de code om een rij aan te maken in de database
        }

        public Rij GetRijById(int id)
        {
            // Implementeer de code om een rij op te halen op basis van het ID
        }

        public IEnumerable<Rij> GetAllRijenByVakId(int vakId)
        {
            // Implementeer de code om alle rijen op te halen op basis van het Vak_ID
        }

        public void UpdateRij(Rij rij)
        {
            // Implementeer de code om een rij bij te werken
        }

        public void DeleteRij(int id)
        {
            // Implementeer de code om een rij te verwijderen op basis van het ID
        }
    }
}
