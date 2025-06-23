using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class SalaDAO:IDAO<Sala>
    {

        public SalaDAO()
        {
            
        }

        public List<Sala> GetAll()
        {
            List<Sala> salas = new List<Sala>();

            try
            {
                string sql = $"SELECT * FROM Salas " + 
                "ORDER BY numero_sal";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sala sala = new Sala(
                            dr.GetInt32("id_sal"), 
                            dr.GetInt32("numero_sal"));
                        salas.Add(sala);
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
            return salas;
        }
        public Sala GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Sala sala = new Sala();

            if (sala == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return sala;
        }
   
    }
}