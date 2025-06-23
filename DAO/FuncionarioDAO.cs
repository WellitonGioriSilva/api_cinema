using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class FuncionarioDAO:IDAO<Funcionario>
    {

        public FuncionarioDAO()
        {
            
        }

        public List<Funcionario> GetAll(string nome)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            try
            {
                string filter = "";
                if (nome != "") filter = "WHERE nome_fun LIKE @nome";

                string sql = $"SELECT * FROM Funcionarios " + 
                $"{filter} ORDER BY nome_fun";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (nome != "") comando.Parameters.AddWithValue("@nome", $"{nome}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Funcionario funcionario = new Funcionario(
                            dr.GetInt32("id_fun"), 
                            dr.GetString("nome_fun"),
                            dr.GetString("cpf_fun"),
                            dr.GetDateTime("dt_nascimento_fun"),
                            dr.GetString("rg_fun"),
                            dr.GetDouble("salario_fun")
                            );
                        funcionarios.Add(funcionario);
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
            return funcionarios;
        }
        public Funcionario GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Funcionario funcionario = new Funcionario();

            if (funcionario == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return funcionario;
        }
   
    }
}