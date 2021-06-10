using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaFerrata.Models
{
    public class Experienta
    {
        public Guid ID { get; set; }

        public string Nume { get; set; }

        public string Varsta { get; set; }

        public string TraseeParcurse { get; set; }

        public string Dificultate { get; set; }
    }
}
