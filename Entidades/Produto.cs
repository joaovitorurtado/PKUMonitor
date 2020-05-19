    using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    class Produto : BaseDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public float QuantiaProteina { get; set; }
        public int Porcao { get; set; }
        public string CodigoBarra { get; set; }
        public override string ToString()
        {
            return Nome;
        }

    }
}
