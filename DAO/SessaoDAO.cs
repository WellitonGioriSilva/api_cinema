using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class SessaoDAO:IDAO<Sessao>
    {

        public SessaoDAO()
        {
            
        }

        public List<Sessao> GetAll(int? id_filme_fk, DateTime? data)
        {
            List<Sessao> sessoes = new List<Sessao>();

            try
            {
                string dataFormatada = data.HasValue ? data.Value.ToString("yyyy-MM-dd") : null;

                string filter = "";
                if (id_filme_fk != 0 && id_filme_fk != null) filter = "WHERE id_filme_fk = @id_fil";
                if (dataFormatada != null)
                {
                    if(filter == "") filter += "WHERE ";
                    else filter += " AND ";

                    filter += "data_ses = @data";
                }

                string sql = $"SELECT s.*, f.* FROM Sessoes AS s " +
                "INNER JOIN Filmes AS f ON f.id_fil = s.id_filme_fk " +
                $"{filter} ORDER BY s.id_ses";
                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (id_filme_fk != 0 && id_filme_fk != null) comando.Parameters.AddWithValue("@id_fil", $"{id_filme_fk}");
                if (dataFormatada != null) comando.Parameters.AddWithValue("@data", $"{dataFormatada}");

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
        public Sessao GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Sessao sessao = new Sessao();

            if (sessao == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return sessao;
        }
        
        public void create(Filme filme)
        {
            // if(filme.id <= 0) throw new ArgumentException("Id inválido!");
            //filmes.Add(filme);
        }
    }
}