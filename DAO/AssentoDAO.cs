using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class AssentoDAO:IDAO<Assento>
    {

        public AssentoDAO()
        {
            
        }

        public List<Assento> GetAll()
        {
            List<Assento> assentos = new List<Assento>();

            try
            {
                string sql = $"SELECT a.*, s.* FROM Assentos AS a " + 
                "INNER JOIN Salas AS s ON s.id_sal = a.id_sala_fk " +
                "ORDER BY a.numero_ass";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sala sala = new Sala(
                            dr.GetInt32("id_sal"), 
                            dr.GetInt32("numero_sal")
                        );
                        Assento assento = new Assento(
                            dr.GetInt32("id_ass"), 
                            dr.GetInt32("numero_ass"),
                            sala);
                        assentos.Add(assento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return assentos;
        }
        public Assento GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Assento assento = new Assento();

            if (assento == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return assento;
        }
        public List<Assento> GetAllFree(int idSessao, out int totalAssentos)
        {
            List<Assento> assentos = new List<Assento>();
            totalAssentos = 0;

            try
            {
                string sqlLivres = $"SELECT a.id_ass, a.numero_ass " +
                    "FROM Assentos AS a " +
                    "INNER JOIN Sessoes AS s " +
                        "ON s.id_sala_fk = a.id_sala_fk " +
                    "LEFT JOIN Ingressos AS i " +
                        "ON i.id_assento_fk = a.id_ass AND i.id_sessao_fk = s.id_ses " +
                    "WHERE i.id_ing IS NULL AND s.id_ses = @id_sessao";

                string sqlTotal = "SELECT COUNT(*) AS Total " + 
                    "FROM Assentos " + 
                    "WHERE id_sala_fk = (SELECT id_sala_fk FROM Sessoes WHERE id_ses = @id_sessao)";

                MySqlCommand comandoTotal = new MySqlCommand(sqlTotal, Connection.OpenConnection());
                MySqlCommand comandoLivres = new MySqlCommand(sqlLivres, Connection.OpenConnection());
                comandoTotal.Parameters.AddWithValue("@id_sessao", idSessao);
                comandoLivres.Parameters.AddWithValue("@id_sessao", idSessao);

                using (MySqlDataReader dr = comandoLivres.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Assento assento = new Assento(
                            dr.GetInt32("id_ass"), 
                            dr.GetInt32("numero_ass"));
                        assentos.Add(assento);
                    }
                }

                using (MySqlDataReader dr = comandoTotal.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        totalAssentos = dr.GetInt32("Total");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return assentos;
        }
    }
}