using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using api_cinema.Interfaces;
using api_cinema.Models.Graficos;
using api_cinema.Utilities;

namespace api_cinema.DAO.Graficos
{
    public class ProdutoMaisVendidoDAO
    {
        public List<ProdutoMaisVendido> GetAll()
        {
            List<ProdutoMaisVendido> produtos = new List<ProdutoMaisVendido>();

            try
            {
                string sql = 
                $"SELECT p.nome_prod, SUM(pv.quantidade_prod_ven) AS quantidade_vendida FROM Produtos_Venda AS pv " +
                "INNER JOIN Produtos AS p " +
                    "ON p.id_prod = pv.id_produto_fk " +
                "GROUP BY p.id_prod " +
                "ORDER BY quantidade_vendida DESC";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ProdutoMaisVendido produto = new ProdutoMaisVendido(
                            dr.GetString("nome_prod"),
                            dr.GetInt32("quantidade_vendida")
                            );
                        produtos.Add(produto);
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
            return produtos;
        }

    }
}