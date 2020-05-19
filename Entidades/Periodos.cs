using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    class Periodos:BaseDTO
    {
        public string IdConjunto { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public string Nome { get; set; }
        public override string ToString()
        {
            return $"{Nome} ({inicio.ToShortDateString()} - {fim.ToShortDateString()})";
        }
    }
}
