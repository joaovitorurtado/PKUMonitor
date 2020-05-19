using PKUMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKUMonitor.Modelos
{
    class NovoProduto
    {
        public Produto Produto{ get; set;}
        public List<Produto> Produto2{get
            {
                Repositorio<Produto> repositorio = new Repositorio<Produto>();
                return repositorio.Read.ToList();
            }
        }
        public NovoProduto()
        {
            Produto = new Produto();
        }
        public Produto ProdutoSelecionado { get; set; }
    }
}
