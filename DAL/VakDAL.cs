using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace DAL
{
    public class VakDAL : IVakDAL
    {
        private readonly string _connectionString;

        public VakDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateVak(Vak vak)
        {
            // Implementeer de code om een vak aan te maken in de database
        }

        public Vak GetVakById(int id)
        {
            // Implementeer de code om een vak op te halen op basis van het ID
        }

        public IEnumerable<Vak> GetAllVakkenByEvenementId(int evenementId)
        {
            // Implementeer de code om alle vakken op te halen op basis van het Evenement_ID
        }

        public void UpdateVak(Vak vak)
        {
            // Implementeer de code om een vak bij te werken
        }

        public void DeleteVak(int id)
        {
            // Implementeer de code om een vak te verwijderen op basis van het ID
        }
    }

}
