using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;

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
                if (nome != "") filter = "WHERE nome_fil LIKE @nome";
                if (id != 0 && id != null) filter = "WHERE id_fil = @id";

                string sql = $"SELECT * FROM Filmes {filter} ORDER BY id_fil";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (nome != "") comando.Parameters.AddWithValue("@nome", $"{nome}%");
                if (id != 0 && id != null) comando.Parameters.AddWithValue("@id", $"{id}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Filme filme = new Filme(
                            dr.GetInt32("id_fil"), 
                            dr.GetString("nome_fil"),
                            dr.GetString("sinopse_fil"),
                            dr.GetTimeSpan("duracao_fil"));

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