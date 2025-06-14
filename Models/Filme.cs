using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Filme
    {
        public int id { get; private set; }
        [Required]
        public string nome { get; private set; }

        public Filme(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}