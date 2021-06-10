using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaFerrata.Models
{
    public class Traseu
    {
        public Guid ID { get; set; }

        public string NumeSiLocatie { get; set; }

        public string Dificultate { get; set; }

        public string Durata { get; set; }

        public string Taxa { get; set; }
    }
}
