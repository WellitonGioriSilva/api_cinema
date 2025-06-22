using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class FormaPagamentoDAO:IDAO<FormaPagamento>
    {

        public FormaPagamentoDAO()
        {
            
        }

        public List<FormaPagamento> GetAll(string nome)
        {
            List<FormaPagamento> formaPagamentos = new List<FormaPagamento>();

            try
            {
                string filter = "";
                if (nome != "") filter = "WHERE nome_for_pag LIKE @nome";

                string sql = $"SELECT * FROM Formas_Pagamento " + 
                $"{filter} ORDER BY nome_for_pag";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (nome != "") comando.Parameters.AddWithValue("@nome", $"{nome}%");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FormaPagamento formaPagamento = new FormaPagamento(
                            dr.GetInt32("id_for_pag"), 
                            dr.GetString("nome_for_pag"));
                        formaPagamentos.Add(formaPagamento);
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
            return formaPagamentos;
        }
        public FormaPagamento GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            FormaPagamento formaPagamento = new FormaPagamento();

            if (formaPagamento == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return formaPagamento;
        }
   
    }
}