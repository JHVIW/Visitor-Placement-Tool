using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace DAL
{
    public class StoelDAL : IStoelDAL
    {
        private readonly string _connectionString;

        public StoelDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateStoel(Stoel stoel)
        {
            // Implementeer de code om een stoel aan te maken in de database
        }

        public Stoel GetStoelById(int id)
        {
            //Implementeer de code om een stoel op te halen op basis van het ID
        }
        public IEnumerable<Stoel> GetAllStoelenByRijId(int rijId)
        {
            // Implementeer de code om alle stoelen op te halen op basis van het Rij_ID
        }

        public void UpdateStoel(Stoel stoel)
        {
            // Implementeer de code om een stoel bij te werken
        }

        public void DeleteStoel(int id)
        {
            // Implementeer de code om een stoel te verwijderen op basis van het ID
        }
    }
}
