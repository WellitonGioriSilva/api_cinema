using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Assento
    {
        public int _id { get; private set; }
        public int _numero { get; private set; }
        public Sala _sala { get; private set; }
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