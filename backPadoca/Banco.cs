using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca
{
    public static class Banco
    {
       private static string stringDeConecxao = "Server=10.91.45.52;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678"; 
        

       public static void connectAndTest()
        {
            using (var connection = new MySqlConnection(stringDeConecxao))
            {
                try
                {
                    Console.WriteLine("Tentando Conectar Ao Banco De Dados");
                    connection.Open();

                    Console.WriteLine( "Conecxão Bem Sucedida");

                    using (var command = new MySqlCommand("SELECT VERCION();", connection))
                    {
                        string version = command.ExecuteScalar()?.ToString();
                        Console.WriteLine($"Versão Do MariaDB {version}");
                    }

                }catch (MySqlException ex)
                {
                    Console.WriteLine("Erro Ao Conectar No Banco De Dados");
                    Console.WriteLine(ex.Message);
                }



            }



        }




    }
}
