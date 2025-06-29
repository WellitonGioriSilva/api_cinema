using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models.Graficos
{
    public class FaturamentoMensal
    {
        public string _anoGraf { get; set; }
        public string _mesGraf{ get; set; }
        public double _totalEntradaMensalGraf { get; set; }
        public double _totalSaidaMensalGraf { get; set; }
        public double _totalLucroMensalGraf { get; set; }

        public FaturamentoMensal(string ano, string mes, double totalEntradaMensal, double totalSaidaMensal, double totalLucroMensalGraf){
            _anoGraf = ano;
            _mesGraf = mes;
            _totalEntradaMensalGraf = totalEntradaMensal;
            _totalSaidaMensalGraf = totalSaidaMensal;
            _totalLucroMensalGraf = totalLucroMensalGraf;
        }
    }
}