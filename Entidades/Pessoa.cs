using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    public class Pessoa:BaseDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EsAdministrador { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NumCasa { get; set; }
        public string IdConjunto { get; set; }
        public float Proteina { get; set; }
        public float ProteinaTotal { get; set; }
        public float ProteinaBar { get; set; }
    }
}
