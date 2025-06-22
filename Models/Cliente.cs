using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models
{
    public class Cliente
    {
        public int _id { get; private set; }
        public string _nome { get; private set; }
        public string _cpf { get; private set; }
        public DateTime _dtNascimento { get; private set; }
        public Cliente()
        {
           
        }
        public Cliente(int id, string nome, string cpf, DateTime dtNascimento)
        {
            _id = id;
            _nome = nome;
            _cpf = cpf;
            _dtNascimento = dtNascimento;
        }
    }
}