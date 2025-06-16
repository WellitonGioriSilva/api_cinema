using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class CategoriaFilme
    {
        public int _id { get; private set; }
        [Required]
        public string _nome { get; private set; }

        public CategoriaFilme(){

        }

        public CategoriaFilme(int id, string nome){
            _id = id;
            _nome = nome;
        }
    }
}