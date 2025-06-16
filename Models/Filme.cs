using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Filme
    {
        public int _id { get; private set; }
        [Required]
        public string _nome { get; private set; }
        public string _sinopse { get; private set; }
        [Required]
        public TimeSpan _duracao { get; private set; }
         public CategoriaFilme _categoria { get; private set; }
        public Filme()
        {
           
        }
        public Filme(int id, string nome, string sinopse, TimeSpan duracao, CategoriaFilme categoria = null)
        {
            _id = id;
            _nome = nome;
            _sinopse = sinopse;
            _duracao = duracao;
            _duracao = duracao;
            _categoria = categoria;
        }
    }
}