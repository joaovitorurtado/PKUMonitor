using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    public class Conjunto:BaseDTO
    {
        public string Direccion { get; set; }
        public string IdRepresentante { get; set; }
        public string Nome { get; set; }
        public override string ToString()
        {
            return Nome;
        }
    }
}
