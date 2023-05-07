using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace DAL
{
    public class EvenementDAL : IEvenementDAL
    {
        private readonly string _connectionString;

        public EvenementDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateEvenement(Evenement evenement)
        {
            // Implementeer de code om een evenement aan te maken in de database
        }

        public Evenement GetEvenementById(int id)
        {
            // Implementeer de code om een evenement op te halen op basis van het ID
        }

        public IEnumerable<Evenement> GetAllEvenementen()
        {
            // Implementeer de code om alle evenementen op te halen
        }

        public void UpdateEvenement(Evenement evenement)
        {
            // Implementeer de code om een evenement bij te werken
        }

        public void DeleteEvenement(int id)
        {
            // Implementeer de code om een evenement te verwijderen op basis van het ID
        }
    }
}
