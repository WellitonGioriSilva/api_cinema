using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Sessao
    {
        public int _id { get; private set; }
        public double _valor {get; private set; }
        public bool _meia { get; private set; }
        public DateTime _data { get; private set; }
        public TimeSpan _hora { get; private set; }
        public Filme _filme { get; private set; }
        public Sala _sala { get; private set; }

        public Sessao(){

        }

        public Sessao(int id, double valor, bool meia, DateTime data, TimeSpan hora, Filme filme = null, Sala sala = null){
            _id = id;
            _valor = valor;
            _meia = meia;
            _data = data;
            _hora = hora;
            _filme = filme;
            _sala = sala;
        }
    }
}