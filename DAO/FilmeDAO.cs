using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;

namespace api_cinema.DAO
{
    public class FilmeDAO
    {

        public FilmeDAO()
        {
            
        }

        public List<Filme> getAll(int id, string nome)
        {
            List<Filme> filmes = new List<Filme>();

            try
            {
                string filter = "";
                if (id != 0 && id != null) filter = "WHERE id_fil = @id";
                else if (nome != "") filter = "WHERE nome_fil LIKE @nome";

                string sql = $"SELECT f.*, c.nome_cat_fil AS categoria FROM Filmes AS f " + 
                "INNER JOIN Categorias_Filme AS c ON c.id_cat_fil = f.id_categoria_fk" +
                $"{filter} ORDER BY f.id_fil";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (id != 0 && id != null) comando.Parameters.AddWithValue("@id", $"{id}%");
                else if (nome != "") comando.Parameters.AddWithValue("@nome", $"{nome}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CategoriaFilme categoria = new CategoriaFilme(
                            dr.GetInt32("id_categoria_fk"),
                            dr.GetString("categoria"));

                        Filme filme = new Filme(
                            dr.GetInt32("id_fil"), 
                            dr.GetString("nome_fil"),
                            dr.GetString("sinopse_fil"),
                            dr.GetTimeSpan("duracao_fil"),
                            categoria);
                        filmes.Add(filme);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return filmes;
        }
        public Filme getById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Filme filme = new Filme();

            if (filme == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return filme;
        }
        
        public void create(Filme filme)
        {
            // if(filme.id <= 0) throw new ArgumentException("Id inválido!");
            //filmes.Add(filme);
        }
   
    }
}