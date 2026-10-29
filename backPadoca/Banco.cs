using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca
{
    public static class Banco
    {
       private static string stringDeConecxao = "Server=10.91.45.40;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678"; 
        

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

        // Declaração do método: público e estático, retorna um número inteiro (linhas afetadas)
        // e recebe um objeto MySqlCommand com a instrucao SQL ja configurada como paranetro.
        public static int ExecutarComando(MySqlCommand command)
        {
            /* O bloco 'using' garante que a conexao sera automaticamente fechada e liberada
             da nenoria ao final do bloco, mesmo que ocorram erros no meio do processo.

            Cria a conexao utilizando a variavel de ambiente.*/
            using (var conexao = new MySqlConnection(stringDeConecxao))
            {
                // Vinculacao: Diz ao comando SQL em qual conexao ele deve ser executado.
                command.Connection = conexao;

                try
                {
                    // Abertura da conexao: Estabelece efetivamente a comunicacao com o servidor MYSQL.
                    conexao.Open();

                    // Execucão: 0 ExecuteNonQuery dispara comandos de ação (INSERT, UPDATE, DELETE).
                    // Ele nao retorna registros, mas sim o numero inteiro de linhas que foram alteradas,
                    // e o 'return' devolve esse numero para quem chanou o metodo.

                    return command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro De Banco De Dados {ex.Message}");
                    return -1;

                }
                ;
            }
        }
                // Metodo RetornoComId

        // Metodo central para executar comandos de consulta (SELECT) no banco de dados.
        // Ele retorna um MySqlDataReader, que e uma especie de "ponteiro" para ler os dados linha por linha.

        public static MySqlDataReader ExecutarComRetornoDeDados(MySqlCommand command)
        {
            // Cria a conexão com o banco.
            // ATENÇÃO: Aqui NÃO usamos o bloco 'using' para a conexão. Se usássemos, a conexão
            // seria fechada antes de retornar os dados, e o programa quebraria ao tentar ler a tabela.
            var conexao = new MySqlConnection(stringDeConecxao);

            try
            {
                // Abre a porta de comunicação com o MySql
                command.Connection = conexao;
                conexao.Open();

                // Executa a consulta e retorna o "leitor" de dados.
                // O CommandBehavior.CloseConnection e a peca-chave deste metodo: ele avisa ao leitor
                // que assin que ele (o leitor) for fechado ou descartado la na tela/classe que o chamou,
                // a conexao com o banco deve ser fechada automaticamente junto con ele.
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (MySqlException ex)
            {

                // O Dispone() ja executa o Close() e libera a memoria.
                conexao.Dispose();


                Console.WriteLine($"Erro na leitura do banco de dados: {ex.Message}");

                // Ao inves de retornar null, relança o erro (throw) para que o metodo que
                // chamou este ExecuteReader saiba que a pesquisa falhou e possa tratar a tela do usuário.

                throw;
            }
        }

        internal static int executarComando(MySqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        internal static object ExecutarComandoComRetornoId(MySqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        internal static MySqlDataReader executarComRetornoDeDados(MySqlCommand cmd)
        {
            throw new NotImplementedException();
        }
    }           
}
