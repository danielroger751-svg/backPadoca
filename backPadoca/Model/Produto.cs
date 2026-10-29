using backPadoca;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Produto
    {
        private int id;
        private string nome;
        private decimal preco;
        private string categoria;
        private bool fabricado;
        private int marcaId;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public bool Fabricado { get => fabricado; set => fabricado = value; }
        public int MarcaId { get => marcaId; set => marcaId = value; }


        public Produto(string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {

            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do produto não pode ser vazio.");
            if (preco < 0) throw new Exception("o preço do produto não pode ser negativo");
            if (string.IsNullOrEmpty(categoria)) throw new Exception("A categoria não pode ser vazia");
            if (marcaId <= 0) throw new Exception("O id da Marca deve ser maior que 0");

            this.nome = nome;
            this.preco = preco;
            this.categoria = categoria;
            this.fabricado = fabricado;
            this.marcaId = marcaId;
        }


        public Produto(int id, string nome, decimal preco, string categoria, bool fabricado, int marcaId) : this(nome, preco, categoria, fabricado, marcaId)
        {

            if (id <= 0) throw new Exception("O ID do produto é invalido");

            this.id = id;
        }

        public Produto(int id)
        {
            this.id = id;
        }



        public static int Inserir(Produto produto)
        {
            // Instrução SQL: Define o comando de inserção (INSERT).
            // 0 uso de marcações com '0' (ex: ONone) é una pratica de segurança crucial chanada de "Paranetrização".
            // Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário.

            string sql = "INSERT INTO `Produto` (`nome`, `preco`, `categoria`, `fabricado`, `marcaId`) VALUES (@Nome, @Preco, @Categoria, @Fabricado, @MarcaId)";

            // Gerenciamento de recursos: Cria o objeto de comando ja passando a instrução SQL.
            // 0 'using' garante que os recursos de nemoria ocupados pelo comando sejam Liberados ao final do bloco.
            using (var cmd = new MySqlCommand(sql))
            {
                // Vinculação de Dados: Pega as propriedades do objeto C# (cliente.Nome, cliente.cpf, etc.)
                // e substitui de forna segura as narcacões '0' da string SQL com os valores reais,

                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId);

                // Execucão: Como o comando de INSERT nao retorna tabelas (apenas executa una ação),
                // ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco'.
                // O metodo retorna 1 (se o usuario for inserido con sucesso) ou -1 (se houver erro no banco).

                return Banco.ExecutarComando(cmd);
            }
        }

        public static int Deletar(Produto produto)
        {
            // String SQL
            string sql = "DELETE FROM `Produto` WHERE `ID` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", produto.id);

                return Banco.ExecutarComando(cmd);
            }
        }

        public static List<Produto> ListarTodos()
        {
            string sql = "SELECT * FROM `Produto`";

            List<Produto> listaProdutos = new();

            using (var cmd = new MySqlCommand(sql))
            {

                // Executa a leitura. 0 bloco 'using' aqui e FUNDAMENTAL para garantir que o
                // reader seja fechado no final, o que por sua vez fecha a conexao com o banco.
                using (MySqlDataReader reader = Banco.ExecutarComRetornoDeDados(cmd))
                {

                    // O while vai rodar uma vez para CADA Linha que existir na tabela Cliente
                    while (reader.Read())
                    {
                        // (int id, string nome, decimal preco, string categoria, bool fabricado, int marcaId)

                        // Extrai os dados da linha atual.
                        int id = reader.GetInt32("Id");
                        string nome = ValidarCampo(reader["Nome"]);
                        decimal preco = reader.GetDecimal("Preco");
                        string categoria = ValidarCampo(reader["Categoria"]);
                        bool fabricado = reader.GetBoolean("Fabricado");
                        int marcaId = reader.GetInt32("MarcaId");

                        // Cria o objeto Cliente con os dados extraidos
                        Produto produto = new Produto(id, nome, preco, categoria, fabricado, marcaId);

                        // Adiciona este cliente à nossa lista
                        listaProdutos.Add(produto);

                    }

                }

                // Retorna a lista completa (se a tabela estiver vazia, retorna uma lista con 0 itens)
                return listaProdutos;

            }

        }


        public static Produto? ListarPorId(int id)
        {
            string sql = "SELECT * FROM `Produto` WHERE `id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.ExecutarComRetornoDeDados(cmd);

                Produto produto = null;

                while (reader.Read())
                {

                    // Extrai os dados da linha atual.
                    int idProduto = reader.GetInt32("Id");
                    string nome = ValidarCampo(reader["Nome"]);
                    decimal preco = reader.GetDecimal("Preco");
                    string categoria = ValidarCampo(reader["Categoria"]);
                    bool fabricado = reader.GetBoolean("Fabricado");
                    int marcaId = reader.GetInt32("MarcaId");

                    // Cria o objeto Cliente con os dados extraidos
                    produto = new Produto(idProduto, nome, preco, categoria, fabricado, marcaId);
                }

                return produto;
            }
        }

        public static int Atualizar(Produto produto)
        {
            string sql = "UPDATE `Produto` SET `Nome` = @Nome, `Preco` = @Preco, `Categoria` = @Categoria, `Fabricado` = @Fabricado, `MarcaId` = @MarcaId WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {

                // Vinculacão de paranetros: Protege contra SQL Injection e organiza os dados
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Fabricado", produto.Fabricado);
                cmd.Parameters.AddWithValue("@MarcaId", produto.MarcaId);

                // A chave de busca: Quem sera atualizado?
                cmd.Parameters.AddWithValue("@Id", produto.id);

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