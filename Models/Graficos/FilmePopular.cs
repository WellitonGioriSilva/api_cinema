using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models.Graficos
{
    public class FilmePopular
    {
        public string _nomeGraf { get; set; }
        public int _quantidadeVendidaGraf { get; set; }

        public FilmePopular(string nomeGraf, int quantidadeVendidaGraf){
            _nomeGraf = nomeGraf;
            _quantidadeVendidaGraf = quantidadeVendidaGraf;
        }
    }
}