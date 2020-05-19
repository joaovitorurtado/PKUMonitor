using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    public class Movimento:BaseDTO
    {
        public string IdConjunto { get; set; }
        public string IdCasa { get; set; }
        public float Monto { get; set; }
        public string idPeriodo { get; set; }
        public bool EsEntrada { get; set; }
        public string Notas { get; set; }
    }
}
