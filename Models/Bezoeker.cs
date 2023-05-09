using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bezoeker
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public int Leeftijd { get; set; }
        public int? Groep_ID { get; set; }
    }
}
