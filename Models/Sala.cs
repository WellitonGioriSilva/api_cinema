using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Sala
    {
        public int _id { get; private set; }
        public int _numero { get; private set; }
        public Sala()
        {
           
        }
        public Sala(int id, int numero)
        {
            _id = id;
            _numero = numero;
        }
    }
}