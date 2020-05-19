using PKUMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Modelos
{
    class NovaContaAdminModel
    {
        public Pessoa Pessoa {get; set;}

        public Conjunto Conjunto { get; set; }
        
        public string Password2 { get; set; }
        public NovaContaAdminModel()
        {
            Pessoa = new Pessoa();
            Conjunto = new Conjunto();
        }

    }
}
