using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class CaixaDAO:IDAO<Caixa>
    {

        public CaixaDAO()
        {
            
        }

        public List<Caixa> GetAll(DateTime? dtIni = null)
        {
            List<Caixa> caixas = new List<Caixa>();

            try
            {
                string filter = "";
                if (dtIni != null) filter = "WHERE dt_ini_cai LIKE @dtIni";

                string sql = $"SELECT * FROM Caixas " + 
                $"{filter} ORDER BY dt_ini_cai";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (dtIni != null) comando.Parameters.AddWithValue("@dtIni", $"{dtIni}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Caixa caixa = new Caixa(
                            dr.GetInt32("id_cai"), 
                            dr.GetDouble("valor_ini_cai"), 
                            dr.GetDouble("total_ent_cai"), 
                            dr.GetDouble("total_sai_cai"), 
                            dr.GetDateTime("dt_ini_cai"),
                            dr.GetDateTime("dt_fim_cai"));
                        caixas.Add(caixa);
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
            return caixas;
        }
        public Caixa GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Caixa caixa = new Caixa();

            if (caixa == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return caixa;
        }

        public void Entrada(int id, double valor)
        {

            try
            {
                if (id == null || id == 0) throw new Exception("Id inválido!");
                // if (valor == null || valor == 0) throw new Exception("Valor deve ser maior do que zero!");

                string sql = $"UPDATE Caixas SET total_ent_cai = total_ent_cai + @valor " + 
                "WHERE id_cai = @id";

                System.Console.WriteLine(sql);

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@valor", valor);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
        }

        public void Saida(int id, double valor)
        {

            try
            {
                if (id == null || id == 0) throw new Exception("Id inválido!");
                // if (valor == null || valor == 0) throw new Exception("Valor deve ser maior do que zero!");

                string sql = $"UPDATE Caixas SET total_sai_cai = total_sai_cai + @valor " + 
                "WHERE id_cai = @id";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@valor", valor);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
        }
    }
}