using api_cinema.Models;

namespace api_cinema.Mapeamento
{
    public class FilmeMap
    {
        public List<Filme> filmes = new List<Filme>();

        public FilmeMap()
        {
            filmes.Add(new Filme(1, "Filme 1"));
            filmes.Add(new Filme(2, "Filme 2"));
        }

        public List<Filme> getAll()
        {
            return filmes;
        }
        public Filme getById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Filme filme = filmes.Find(x => x.id == id);

            if (filme == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return filme;
        }
        
        public void create(Filme filme)
        {
            // if(filme.id <= 0) throw new ArgumentException("Id inválido!");
            filmes.Add(filme);
        }
   
    }
}