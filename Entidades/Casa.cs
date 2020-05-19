using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    public class Casa:BaseDTO
    {
        public string IdConjunto { get; set; }
        public string Numero { get; set; }
        public string IdInquilino { get; set; }
    }
}
