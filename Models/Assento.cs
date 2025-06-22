using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Assento
    {
        public int _id { get; set; }
        public int _numero { get; set; }
        public Sala? _sala { get; set; }
        public Assento()
        {
           
        }
        public Assento(int id, int numero, Sala sala = null)
        {
            _id = id;
            _numero = numero;
            _sala = sala;
        }
    }
}