using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Venda
    {
        public int _id { get; private set; }
        public double _subTotal { get; private set; }
        public DateTime _data { get; private set; }
        public double _desconto { get; private set; }
        public double _total { get; private set; }
        // public Cliente _cliente { get; private set; }
        // public Caixa _caixa { get; private set;}
        // public FormaPgto _formaPgto { get; private set;}


        public Venda()
        {

        }

        public Venda(int id){
            _id = id;
        }
    }
}