using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api_cinema.Utilities
{
    public class Connection
    {
        static MySqlConnection connection;

        public static MySqlConnection OpenConnection(){
            try{
                string strconnection = "server=localhost;port=3306;uid=root;pwd=;database=bd_cinema";
                connection = new MySqlConnection(strconnection);
                connection.Open();
            }catch(Exception ex){
                Console.WriteLine("Erro na conexão do banco de dados: " + ex.Message);
            }

            return connection;
        }

        public static void CloseConnection()
        {
            connection.Close();
        }
    }
}