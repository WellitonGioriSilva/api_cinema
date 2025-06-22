using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models
{
    public class FormaPagamento
    {
        public int _id { get; private set; }
        public string _nome { get; private set; }
        public FormaPagamento()
        {
           
        }
        public FormaPagamento(int id, string nome)
        {
            _id = id;
            _nome = nome;
        }
    }
}