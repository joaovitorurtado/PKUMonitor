using PKUMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKUMonitor.Modelos
{
    class PeriodoModel
    {
        Repositorio<Periodos> repositorioPeriodos;
        public List<Periodos> Periodos { get; set; }
        public Periodos PeriodoSelecionado { get; set; }
        public PeriodoModel()
        {

        }
        public PeriodoModel(string idConjunto)
        {
            repositorioPeriodos = new Repositorio<Periodos>();
            Periodos = repositorioPeriodos.Query(p => p.IdConjunto == idConjunto).ToList();
        }
    }
}
