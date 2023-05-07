using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Evenement
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public int MaximumAantalBezoekers { get; set; }
    }
}
