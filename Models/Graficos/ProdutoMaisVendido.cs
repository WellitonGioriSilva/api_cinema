using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models.Graficos
{
    public class ProdutoMaisVendido
    {
        public string _nomeGraf { get; set; }
        public int _quantidadeVendidaGraf { get; set; }

        public ProdutoMaisVendido(string nomeGraf, int quantidadeVendidaGraf){
            _nomeGraf = nomeGraf;
            _quantidadeVendidaGraf = quantidadeVendidaGraf;
        }
    }
}