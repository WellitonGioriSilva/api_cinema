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
    public class FaturamentoMensalDAO
    {
        public List<FaturamentoMensal> GetAll()
        {
            List<FaturamentoMensal> faturamento = new List<FaturamentoMensal>();

            try
            {
                string sql = 
                $"SELECT YEAR(dt_fim_cai) AS ano, MONTH(dt_fim_cai) AS mes, SUM(total_ent_cai) AS total_entrada_mensal, SUM(total_sai_cai) AS total_saida_mensal, SUM((valor_ini_cai + total_ent_cai) - total_sai_cai) AS total_lucro_mensal " +
                "FROM Caixas " + 
                "GROUP BY ano, mes ORDER BY ano, mes";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FaturamentoMensal mes = new FaturamentoMensal(
                            dr.GetInt32("ano").ToString(),
                            dr.GetInt32("mes").ToString(),
                            dr.GetDouble("total_entrada_mensal"),
                            dr.GetDouble("total_saida_mensal"),
                            dr.GetDouble("total_lucro_mensal")
                            );
                        faturamento.Add(mes);
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
            return faturamento;
        }

    }
}