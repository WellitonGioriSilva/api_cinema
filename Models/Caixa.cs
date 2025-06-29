using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models
{
    public class Caixa
    {
        public int _id { get; private set; }
        public double _valorIni { get; private set; }
        public double _totalEnt { get; private set; }
        public double _totalSai { get; private set; }
        public DateTime _dtIni { get; private set; }
        public DateTime _dtFim { get; private set; }
        public Funcionario _funcionario { get; set; }
        public Caixa()
        {
           
        }
        public Caixa(int id, double valorIni, double totalEnt, double totalSai, DateTime dtIni, DateTime dtFim, Funcionario funcionario = null) 
        {
            _id = id;
            _valorIni = valorIni;
            _totalEnt = totalEnt;
            _totalSai = totalSai;
            _dtIni = dtIni;
            _dtFim = dtFim;
            _funcionario = funcionario;
        }
    }
}