using PKUMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKUMonitor.Modelos
{
    class NovaContaNOOBModel
    {
        public Pessoa Pessoa { get; set; }
        public string Password2 { get; set; }
        public List<Conjunto> Conjunto { get
            {
                Repositorio<Conjunto> repositorio = new Repositorio<Conjunto>();
                return repositorio.Read.ToList();
            }
        }
        public NovaContaNOOBModel()
        {
            Pessoa = new Pessoa();
        }
        public Conjunto ConjuntoSelecionado { get; set; }
    }
    
}
