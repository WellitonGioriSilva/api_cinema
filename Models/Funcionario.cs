using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cinema.Models
{
    public class Funcionario
    {
        public int _id { get; private set; }
        public string _nome { get; private set; }
        public string _cpf { get; private set; }
        public DateTime _dtNascimento { get; private set; }
        public string _rg { get; private set; }
        public double _salario { get; private set; }
        public Funcionario()
        {
           
        }
        public Funcionario(int id, string nome, string cpf, DateTime dtNascimento, string rg, double salario)
        {
            _id = id;
            _nome = nome;
            _cpf = cpf;
            _dtNascimento = dtNascimento;
            _rg = rg;
            _salario = salario;
        }
    }
}