using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;

namespace api_cinema.DAO
{
    public class SessaoDAO
    {

        public SessaoDAO()
        {
            
        }

        public List<Sessao> getAll(int id, int id_filme_fk)
        {
            List<Sessao> sessoes = new List<Sessao>();

            try
            {
                string filter = "";
                if (id != 0 && id != null) filter = "WHERE id_ses = @id";
                else if (id_filme_fk != 0 && id_filme_fk != null) filter = "WHERE id_filme_fk LIKE @id_fil";

                string sql = $"SELECT s.*, f.* FROM Sessoes AS s " + 
                "INNER JOIN Filmes AS f ON f.id_fil = s.id_filme_fk " +
                $"{filter} ORDER BY s.id_ses";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (id != 0 && id != null) comando.Parameters.AddWithValue("@id", $"{id}%");
                else if (id_filme_fk != 0 && id_filme_fk != null) comando.Parameters.AddWithValue("@id_fil", $"{id_filme_fk}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Filme filme = new Filme(
                            dr.GetInt32("id_filme_fk"),
                            dr.GetString("nome_fil"),
                            dr.GetString("sinopse_fil"),
                            dr.GetTimeSpan("duracao_fil"));

                        Sessao sessao = new Sessao(
                            dr.GetInt32("id_fil"), 
                            dr.GetDouble("valor_ses"),
                            dr.GetBoolean("meia_ses"),
                            dr.GetDateTime("data_ses"),
                            dr.GetTimeSpan("hora_ses"),
                            filme);
                        sessoes.Add(sessao);
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
            return sessoes;
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