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
    public class FilmePopularDAO
    {
        public List<FilmePopular> GetAll()
        {
            List<FilmePopular> filmes = new List<FilmePopular>();

            try
            {
                string sql = 
                $"SELECT f.nome_fil, COUNT(*) AS quantidade_vendida FROM Ingressos AS i " +
                "INNER JOIN Sessoes AS s  " + 
                    "ON s.id_ses = i.id_sessao_fk " + 
                "INNER JOIN Filmes AS f  " + 
                    "ON f.id_fil = s.id_filme_fk  " + 
                "GROUP BY f.id_fil  " + 
                "ORDER BY quantidade_vendida DESC";

                MySqlCommand comando = new MySqlCommand(sql, Connection.OpenConnection());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FilmePopular filme = new FilmePopular(
                            dr.GetString("nome_fil"),
                            dr.GetInt32("quantidade_vendida")
                            );
                        filmes.Add(filme);
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
            return filmes;
        }

    }
}