using backPadoca;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Cliente
    {

        private int _id;
        private string _nome;
        private string _cpf;
        private string _telefone;
        private string _endereco;
        private int _pontos;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public int Pontos { get => _pontos; set => _pontos = value; }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {

            if (nome == "") throw new Exception("O nome do cliente não pode ser vazio.");

            this._id = id;
            this._nome = nome;
            this._cpf = cpf;
            this._telefone = telefone;
            this._endereco = endereco;
            this._pontos = pontos; //aaa
        }

        // Gambiarra para testar
        public Cliente(int id)
        {
            this._id = id;
        }


        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {

            this._nome = nome;
            this._cpf = cpf;
            this._telefone = telefone;
            this._endereco = endereco;
            this._pontos = pontos;
        }

        public void AdicionarPontos(int pontos)
        {
            this._pontos += pontos;
        }


        public static int Inserir(Cliente cliente)
        {
            // Instrução SQL: Define o comando de inserção (INSERT).
            // 0 uso de marcações com '0' (ex: ONone) é una pratica de segurança crucial chanada de "Paranetrização".
            // Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário.

            string sql = "INSERT INTO `Cliente` (`nome`, `CPF`, `Telefone`, `Endereco`, `Pontos`) VALUES (@Nome, @CPF, @Telefone, @Endereco, @Pontos)";

            // Gerenciamento de recursos: Cria o objeto de comando ja passando a instrução SQL.
            // 0 'using' garante que os recursos de nemoria ocupados pelo comando sejam Liberados ao final do bloco.
            using (var cmd = new MySqlCommand(sql))
            {
                // Vinculação de Dados: Pega as propriedades do objeto C# (cliente.Nome, cliente.cpf, etc.)
                // e substitui de forna segura as narcacões '0' da string SQL com os valores reais,

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Pontos", cliente.Pontos);

                // Execucão: Como o comando de INSERT nao retorna tabelas (apenas executa una ação),
                // ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco'.
                // O metodo retorna 1 (se o usuario for inserido con sucesso) ou -1 (se houver erro no banco).

                return Banco.ExecutarComando(cmd);
            }
        }

        public static int Deletar(Cliente cliente)
        {
            // String SQL
            string sql = "DELETE FROM `Cliente` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", cliente.Id);

                return Banco.ExecutarComando(cmd);
            }
        }

        public static List<Cliente> ListarTodos()
        {
            string sql = "SELECT * FROM `Cliente`";

            List<Cliente> listaClientes = new();

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
                        string cpf = ValidarCampo(reader["Cpf"]);
                        string telefone = ValidarCampo(reader["Telefone"]);
                        string endereco = ValidarCampo(reader["Endereco"]);

                        int pontos = reader.GetInt32("Pontos");

                        // Cria o objeto Cliente con os dados extraidos
                        Cliente cliente = new Cliente(id, nome, cpf, telefone, endereco, pontos);

                        // Adiciona este cliente à nossa lista
                        listaClientes.Add(cliente);

                    }

                }

                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista con 0 itens)
                return listaClientes;

            }

        }


        public static Cliente? ListarPorId(int id)
        {
            string sql = "SELECT * FROM `Cliente` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.ExecutarComRetornoDeDados(cmd);

                Cliente cliente = null;

                while (reader.Read())
                {

                    // Extrai os dados da linha atual.
                    int idBanco = reader.GetInt32("id");

                    string nome = ValidarCampo(reader["Nome"]);
                    string cpf = ValidarCampo(reader["Cpf"]);
                    string telefone = ValidarCampo(reader["Telefone"]);
                    string endereco = ValidarCampo(reader["Endereco"]);

                    int pontos = reader.GetInt32("Pontos");

                    // Cria o objeto Cliente con os dados extraidos
                    cliente = new Cliente(idBanco, nome, cpf, telefone, endereco, pontos);
                }

                return cliente;
            }
        }

        public static int Atualizar(Cliente cliente)
        {
            string sql = "UPDATE `Cliente` SET `Nome` = @Nome, `Cpf` = @Cpf, `Telefone` = @Telefone, `Endereco` = @Endereco, `Pontos` = @Pontos WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {

                // Vinculacão de paranetros: Protege contra SQL Injection e organiza os dados
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Pontos", cliente.Pontos);

                // A chave de busca: Quem sera atualizado?
                cmd.Parameters.AddWithValue("@Id", cliente.Id);

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