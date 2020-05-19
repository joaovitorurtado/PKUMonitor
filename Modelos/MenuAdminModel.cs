using PKUMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKUMonitor.Modelos
{
    class MenuAdminModel
    {
        private Repositorio<Movimento> repositorioMovimento;
        public Pessoa admin { get; set; }
        public float Aportaciones { get; private set; }
        public float Gastos { get; private set; }
        public float Total { get; private set; }
        public MenuAdminModel()
        {

        }
        public MenuAdminModel(Pessoa pessoa)
        {
            admin = pessoa;
            repositorioMovimento = new Repositorio<Movimento>();
            Aportaciones = repositorioMovimento.Query(m => m.IdConjunto == admin.IdConjunto && m.EsEntrada).Sum(n => n.Monto);
            Gastos = repositorioMovimento.Query(m => m.IdConjunto == admin.IdConjunto && !m.EsEntrada).Sum(n => n.Monto);
            Total = Aportaciones - Gastos;
        }
    }
}
