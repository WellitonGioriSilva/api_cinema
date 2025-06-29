using api_cinema.Models;
using api_cinema.Utilities;
using MySql.Data.MySqlClient;
using api_cinema.Models;
using api_cinema.Interfaces;

namespace api_cinema.DAO
{
    public class VendaDAO : IDAO<Venda>
    {

        public VendaDAO()
        {

        }

        public List<Venda> GetAll(DateTime? data = null, int? idCliente = 0)
        {
            List<Venda> vendas = new List<Venda>();

            try
            {
                string filter = "";
                if (data.HasValue) filter = "v.data_ven = @dt AND";
                if (idCliente.HasValue && idCliente != 0) filter = "v.id_cliente_fk = @idCliente AND";

                string sql =
                "SELECT v.*, c.*, cai.*, f.*, pv.id_prod_ven FROM Vendas AS v " +
                "INNER JOIN Clientes AS c ON c.id_cli = v.id_cliente_fk " +
                "INNER JOIN Caixas AS cai ON cai.id_cai = v.id_caixa_fk " +
                "INNER JOIN Formas_Pagamento AS f ON f.id_for_pag = v.id_forma_pagamento_fk " +
                "LEFT JOIN Produtos_Venda AS pv ON pv.id_venda_fk = v.id_ven " +
                $"WHERE {filter} pv.id_prod_ven IS NULL " +
                "ORDER BY v.data_ven";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (data.HasValue) comando.Parameters.AddWithValue("@dt", $"{data}");
                if (idCliente.HasValue && idCliente != 0) comando.Parameters.AddWithValue("@idCliente", $"{idCliente}");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente(
                            dr.GetInt32("id_cli"),
                            dr.GetString("nome_cli"),
                            dr.GetString("cpf_cli"),
                            dr.GetDateTime("dt_nascimento_cli")
                        );

                        Caixa caixa = new Caixa(
                            dr.GetInt32("id_cai"),
                            dr.GetDouble("valor_ini_cai"),
                            dr.GetDouble("total_ent_cai"),
                            dr.GetDouble("total_sai_cai"),
                            dr.GetDateTime("dt_ini_cai"),
                            dr.GetDateTime("dt_fim_cai")
                        );

                        FormaPagamento formaPagamento = new FormaPagamento(
                            dr.GetInt32("id_for_pag"),
                            dr.GetString("nome_for_pag")
                        );

                        Venda venda = new Venda(
                            dr.GetInt32("id_ven"),
                            dr.GetDouble("sub_total_ven"),
                            dr.GetDateTime("data_ven"),
                            dr.GetDouble("desconto_ven"),
                            dr.GetDouble("total_ven"),
                            dr.GetInt32("id_cliente_fk"),
                            dr.GetInt32("id_caixa_fk"),
                            dr.GetInt32("id_forma_pagamento_fk"),
                            cliente,
                            caixa,
                            formaPagamento
                        );
                        vendas.Add(venda);
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
            return vendas;
        }
        public Venda GetById(int id)
        {
            Venda venda = new Venda();

            try
            {
                if (id == 0) throw new ArgumentException("Id inválido!");

                string sql =
                "SELECT v.*, c.*, cai.*, f.*, pv.id_prod_ven FROM Vendas AS v " +
                "INNER JOIN Clientes AS c ON c.id_cli = v.id_cliente_fk " +
                "INNER JOIN Caixas AS cai ON cai.id_cai = v.id_caixa_fk " +
                "INNER JOIN Formas_Pagamento AS f ON f.id_for_pag = v.id_forma_pagamento_fk " +
                "LEFT JOIN Produtos_Venda AS pv ON pv.id_venda_fk = v.id_ven " +
                $"WHERE v.id_ven = @id AND pv.id_prod_ven IS NULL " +
                "ORDER BY v.data_ven";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                if (id != 0) comando.Parameters.AddWithValue("@id", $"{id}");

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente(
                            dr.GetInt32("id_cli"),
                            dr.GetString("nome_cli"),
                            dr.GetString("cpf_cli"),
                            dr.GetDateTime("dt_nascimento_cli")
                        );

                        Caixa caixa = new Caixa(
                            dr.GetInt32("id_cai"),
                            dr.GetDouble("valor_ini_cai"),
                            dr.GetDouble("total_ent_cai"),
                            dr.GetDouble("total_sai_cai"),
                            dr.GetDateTime("dt_ini_cai"),
                            dr.GetDateTime("dt_fim_cai")
                        );

                        FormaPagamento formaPagamento = new FormaPagamento(
                            dr.GetInt32("id_for_pag"),
                            dr.GetString("nome_for_pag")
                        );

                        venda = new Venda(
                            dr.GetInt32("id_ven"),
                            dr.GetDouble("sub_total_ven"),
                            dr.GetDateTime("data_ven"),
                            dr.GetDouble("desconto_ven"),
                            dr.GetDouble("total_ven"),
                            dr.GetInt32("id_cliente_fk"),
                            dr.GetInt32("id_caixa_fk"),
                            dr.GetInt32("id_forma_pagamento_fk"),
                            cliente,
                            caixa,
                            formaPagamento
                        );
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

            return venda;
        }
        public void Create(Venda venda, List<Assento> assentos, int sessaoId, int quantidadeMeiaEntrada)
        {
            try
            {
                string campos = "";
                string valores = "";
                if (venda._clienteId != 0)
                {
                    campos = ", id_cliente_fk";
                    valores = ", @cliente";
                }
                ;

                string sql = $"INSERT INTO Vendas (sub_total_ven, data_ven, desconto_ven, total_ven, id_caixa_fk, id_forma_pagamento_fk{campos}) " +
               $"VALUES (@subTotal, @data, @desconto, @total, @caixa, @formaPagamento{valores});";

                string data = venda._data.ToString("yyyy-MM-dd");
                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@subTotal", $"{venda._subTotal}");
                comando.Parameters.AddWithValue("@data", $"{data}");
                comando.Parameters.AddWithValue("@desconto", $"{venda._desconto}");
                comando.Parameters.AddWithValue("@total", $"{venda._total}");
                if (venda._clienteId != 0) comando.Parameters.AddWithValue("@cliente", $"{venda._clienteId}");
                comando.Parameters.AddWithValue("@caixa", $"{venda._caixaId}");
                comando.Parameters.AddWithValue("@formaPagamento", $"{venda._formaPagamentoId}");
                comando.ExecuteNonQuery();

                GeraIngressos(assentos, quantidadeMeiaEntrada, sessaoId, Convert.ToInt32(comando.LastInsertedId));
                CaixaDAO caixaDAO = new CaixaDAO();
                caixaDAO.Entrada(venda._caixaId, venda._total);
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
        public void Delete(int id)
        {
            try
            {
                if (id == null || id == 0) throw new Exception("O Id de venda é obrigatório!");
                
                string sql = $"DELETE FROM Vendas WHERE id_ven = @id";

                double valorAntigo = GetById(id)._total;
                int caixa = GetById(id)._caixaId;

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

                CaixaDAO caixaDAO = new CaixaDAO();
                caixaDAO.Entrada(caixa, valorAntigo * -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
        }
        public void Update(Venda venda, List<Assento> assentos, int sessaoId, int quantidadeMeiaEntrada)
        {
            try
            {
                if (!venda._id.HasValue || venda._id == 0) throw new Exception("O Id de venda é obrigatório!");

                double valorAntigo = GetById(venda._id ?? 0)._total;
                int caixaAntigo = GetById(venda._id ?? 0)._caixaId;

                IngressoDAO ingressoDAO = new IngressoDAO();
                ingressoDAO.Delete(0, venda._id ?? 0);

                string campos = "";
                if (venda._clienteId != 0)
                {
                    campos = ", id_cliente_fk = @cliente";
                }
                ;

                string sql = $"UPDATE Vendas SET " +
                $"sub_total_ven = @subTotal, " +
                $"data_ven = @data, " +
                $"desconto_ven = @desconto, " +
                $"total_ven = @total, " +
                $"id_caixa_fk = @caixa, " +
                $"id_forma_pagamento_fk = @formaPagamento" +
                $"{campos} " +
                $"WHERE id_ven = @id;";

                string data = venda._data.ToString("yyyy-MM-dd");
                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());
                comando.Parameters.AddWithValue("@subTotal", $"{venda._subTotal}");
                comando.Parameters.AddWithValue("@data", $"{data}");
                comando.Parameters.AddWithValue("@desconto", $"{venda._desconto}");
                comando.Parameters.AddWithValue("@total", $"{venda._total}");
                if (venda._clienteId != 0) comando.Parameters.AddWithValue("@cliente", $"{venda._clienteId}");
                comando.Parameters.AddWithValue("@caixa", $"{venda._caixaId}");
                comando.Parameters.AddWithValue("@formaPagamento", $"{venda._formaPagamentoId}");
                comando.Parameters.AddWithValue("@id", $"{venda._id}");
                comando.ExecuteNonQuery();

                GeraIngressos(assentos, quantidadeMeiaEntrada, sessaoId, venda._id ?? 0);
                CaixaDAO caixaDAO = new CaixaDAO();
                
                caixaDAO.Entrada(caixaAntigo, valorAntigo * -1);
                caixaDAO.Entrada(venda._caixaId, venda._total);
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

        private void GeraIngressos(List<Assento> assentos, int quantidadeMeiaEntrada, int sessaoId, int vendaId)
        {
            try
            {
                IngressoDAO ingressoDAO = new IngressoDAO();
                foreach (Assento assento in assentos)
                {
                    bool meia = false;
                    if (quantidadeMeiaEntrada > 0)
                    {
                        meia = true;
                        quantidadeMeiaEntrada--;
                    }

                    ingressoDAO.Create(new Ingresso(0, meia, sessaoId, vendaId, assento._id));
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}