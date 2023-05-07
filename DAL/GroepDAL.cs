using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace DAL
{
    public class GroepDAL : IGroepDAL
    {
        private readonly string _connectionString;
        public GroepDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateGroep(Groep groep)
        {
            // Implementeer de code om een groep aan te maken in de database
        }

        public Groep GetGroepById(int id)
        {
            // Implementeer de code om een groep op te halen op basis van het ID
        }

        public IEnumerable<Groep> GetAllGroepenByEvenementId(int evenementId)
        {
            // Implementeer de code om alle groepen op te halen op basis van het Evenement_ID
        }

        public void UpdateGroep(Groep groep)
        {
            // Implementeer de code om een groep bij te werken
        }

        public void DeleteGroep(int id)
        {
            // Implementeer de code om een groep te verwijderen op basis van het ID
        }
    }
 }
