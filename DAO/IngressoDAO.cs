using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class IngressoDAO:IDAO<Ingresso>
    {

        public IngressoDAO()
        {
            
        }

        public List<Ingresso> GetAll(int idVenda = 0)
        {
            List<Ingresso> ingressos = new List<Ingresso>();

            try
            {
                string filter = "";
                if (idVenda != null && idVenda != 0) filter = "WHERE id_venda_fk = @idVenda";

                string sql = $"SELECT i.*, s.*, a.*, v.* FROM Ingressos AS i" + 
                "INNER JOIN Sessoes AS s ON s.id_ses = i.id_sessao_fk " + 
                "INNER JOIN Assentos AS a ON a.id_ass = i.id_assento_fk " + 
                "INNER JOIN Vendas AS v ON v.id_ven = i.id_venda_fk " + 
                $"{filter}";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (idVenda != null && idVenda != 0) comando.Parameters.AddWithValue("@idVenda", idVenda);

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sessao sessao = new Sessao(
                            dr.GetInt32("id_fil"), 
                            dr.GetDouble("valor_ses"),
                            dr.GetBoolean("meia_ses"),
                            dr.GetDateTime("data_ses"),
                            dr.GetTimeSpan("hora_ses")
                        );

                        Assento assento = new Assento(
                            dr.GetInt32("id_ass"), 
                            dr.GetInt32("numero_ass")
                        );
                        
                        Venda venda = new Venda(
                            dr.GetInt32("id_ven"),
                            dr.GetDouble("sub_total_ven"),
                            dr.GetDateTime("data_ven"),
                            dr.GetDouble("desconto_ven"),
                            dr.GetDouble("total_ven"),
                            dr.GetInt32("id_cliente_fk"),
                            dr.GetInt32("id_caixa_fk"),
                            dr.GetInt32("id_forma_pagamento_fk")
                        );
                        
                        Ingresso ingresso = new Ingresso(
                            dr.GetInt32("id_ven"),
                            dr.GetBoolean("meia_ing"),
                            dr.GetInt32("id_sessao_fk"),
                            dr.GetInt32("id_assento_fk"),
                            dr.GetInt32("id_venda_fk"),
                            sessao,
                            venda,
                            assento
                        );
                        ingressos.Add(ingresso);
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
            return ingressos;
        }
        public Ingresso GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido!");

            Ingresso ingresso = new Ingresso();

            if (ingresso == null) throw new KeyNotFoundException("Nenhum registro encontrado!");

            return ingresso;
        }

        public void Create(Ingresso ingresso)
        {
            try
            {
                string sql = $"INSERT INTO Ingressos (meia_ing, id_sessao_fk, id_assento_fk, id_venda_fk) " +
                "VALUES (@meia, @sessao, @assento, @venda);";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@meia", $"{ingresso._meia}");
                comando.Parameters.AddWithValue("@sessao", $"{ingresso._sessaoId}");
                comando.Parameters.AddWithValue("@assento", $"{ingresso._assentoId}");
                comando.Parameters.AddWithValue("@venda", $"{ingresso._vendaId}");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
        }
   
    }
}