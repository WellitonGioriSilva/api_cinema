using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class ClienteDAO:IDAO<Cliente>
    {

        public ClienteDAO()
        {
            
        }

        public List<Cliente> GetAll(string nome)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                string filter = "";
                if (nome != "") filter = "WHERE nome_cli LIKE @nome";

                string sql = $"SELECT * FROM Clientes " + 
                $"{filter} ORDER BY nome_cli";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (nome != "") comando.Parameters.AddWithValue("@nome", $"{nome}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente(
                            dr.GetInt32("id_cli"), 
                            dr.GetString("nome_cli"),
                            dr.GetString("cpf_cli"),
                            dr.GetDateTime("dt_nascimento_cli"));
                        clientes.Add(cliente);
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
            return clientes;
        }
        public Cliente GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Cliente cliente = new Cliente();

            if (cliente == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return cliente;
        }
   
    }
}