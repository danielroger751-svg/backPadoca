using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Model
{
        internal class Marca
        {

            private int _id;
            private string _nome;
            private string _descricao;

            public int Id { get => _id; set => _id = value; }
            public string Nome { get => _nome; set => _nome = value; }
            public string Descricao { get => _descricao; set => _descricao = value; }


            public Marca(int id, string nome, string descricao)
            {
                this._id = id;
                this._nome = nome;
                this._descricao = descricao;
            }

            public Marca(string nome, string descricao)
            {
                this._nome = nome;
                this._descricao = descricao;
            }

            public static int Inserir(Marca marca)
            {
                // Instrução SQL: Define o comando de inserção (INSERT).
                // 0 uso de marcações com '0' (ex: ONone) é una pratica de segurança crucial chanada de "Paranetrização".
                // Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário.

                string sql = "INSERT INTO `Marca` (`nome`,`Telefone`) VALUES (@Nome, @Telefone)";

                // Gerenciamento de recursos: Cria o objeto de comando ja passando a instrução SQL.
                // 0 'using' garante que os recursos de nemoria ocupados pelo comando sejam Liberados ao final do bloco.
                using (var cmd = new MySqlCommand(sql))
                {
                    // Vinculação de Dados: Pega as propriedades do objeto C# (cliente.Nome, cliente.cpf, etc.)
                    // e substitui de forna segura as narcacões '0' da string SQL com os valores reais,

                    cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);

                    // Execucão: Como o comando de INSERT nao retorna tabelas (apenas executa una ação),
                    // ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco'.
                    // O metodo retorna 1 (se o usuario for inserido con sucesso) ou -1 (se houver erro no banco).

                    return Banco.ExecutarComando(cmd);
                }
            }

            public static int Deletar(Marca marca)
            {
                // String SQL
                string sql = "DELETE FROM `Marca` WHERE `ID` = @id";

                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@id", marca.Id);

                    return Banco.ExecutarComando(cmd);
                }
            }

            public static List<Marca> ListarTodos()
            {
                string sql = "SELECT * FROM `Marca`";

                List<Marca> listaMarcas = new();

                using (var cmd = new MySqlCommand(sql))
                {

                    // Executa a leitura. 0 bloco 'using' aqui e FUNDAMENTAL para garantir que o
                    // reader seja fechado no final, o que por sua vez fecha a conexao com o banco.
                    using (MySqlDataReader reader = Banco.ExecutarComRetornoDeDados(cmd))
                    {

                        // O while vai rodar uma vez para CADA Linha que existir na tabela Cliente
                        while (reader.Read())
                        {

                            // Extrai os dados da linha atual.
                            int id = reader.GetInt32("id");

                            string nome = ValidarCampo(reader["Nome"]);
                            string telefone = ValidarCampo(reader["Descricao"]);


                            // Cria o objeto Cliente con os dados extraidos
                            Marca marca = new Marca(id, nome, telefone);

                            // Adiciona este cliente à nossa lista
                            listaMarcas.Add(marca);

                        }

                    }

                    // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista con 0 itens)
                    return listaMarcas;

                }

            }


            public static Marca? ListarPorId(int id)
            {
                string sql = "SELECT * FROM `Marca` WHERE `id` = @Id";

                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    MySqlDataReader reader = Banco.ExecutarComRetornoDeDados(cmd);

                    Marca marca = null;

                    while (reader.Read())
                    {

                        // Extrai os dados da linha atual.
                        int idMarca = reader.GetInt32("id");
                        string nome = ValidarCampo(reader["Nome"]);
                        string descricao = ValidarCampo(reader["Descricao"]);

                        // Cria o objeto Cliente con os dados extraidosc
                        marca = new Marca(idMarca, nome, descricao);
                    }

                    return marca;
                }
            }

            public static int Atualizar(Marca marca)
            {
                string sql = "UPDATE `Marca` SET `Nome` = @Nome, `Descricao` = @Descricao WHERE `Id` = @Id";

                using (var cmd = new MySqlCommand(sql))
                {

                    // Vinculacão de paranetros: Protege contra SQL Injection e organiza os dados
                    cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);

                    // A chave de busca: Quem sera atualizado?
                    cmd.Parameters.AddWithValue("@Id", marca.Id);

                    // Execução: 0 UPOATE tambén é uma instrução de ação (cono INSERT e DELETE).
                    // Ele vai retornar 1 (se encontrou o ID e atualizou con sucesso) ou 0 (se o ID nao existia).
                    return Banco.ExecutarComando(cmd);

                }
            }


            private static string ValidarCampo(object campo)
            {

                if (campo == DBNull.Value || campo == null)
                {
                    return "";
                }
                else
                {
                    return campo.ToString();

                }


            }






        }
}

