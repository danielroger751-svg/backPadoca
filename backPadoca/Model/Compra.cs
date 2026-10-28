using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Model
{
        internal class Compra

        {

            private int _id;

            private DateTime _dataHora;

            private int _funcionarioId;

            private int _clienteId;

            private List<ItemCompra> _itens = new List<ItemCompra>();

            public int Id { get => _id; set => _id = value; }

            public DateTime DataHora { get => _dataHora; set => _dataHora = value; }

            public int FuncionarioId { get => _funcionarioId; set => _funcionarioId = value; }

            public int ClienteId { get => _clienteId; set => _clienteId = value; }


            // Método Construtor sem ID.

            public Compra(DateTime dataHora, int funcionarioId, int clienteId)

            {

                if (funcionarioId <= 0) throw new ArgumentOutOfRangeException("O funcionario responsavel é inválido.");

                this._dataHora = dataHora;

                this._funcionarioId = funcionarioId;

                this._clienteId = clienteId;

            }


            // Método construtor com ID.

            public Compra(int id, DateTime dataHora, int funcionarioId, int clienteId) : this(dataHora, funcionarioId, clienteId)

            {

                if (id <= 0) throw new ArgumentOutOfRangeException("ID da compra inválida.");

                this._id = id;

            }

            // Método construtor para Calcular o valor total.

            public decimal CalcularTotal()

            {

                // Percorre todos os itens da coleção, calcula o subtotal de cada item

                // através do método CalcularSubtotal() e retorna a soma de todos eles.

                return _itens.Sum(item => item.CalcularSubtotal());


                // OU


                /*

                decimal vTotal = 0;

                foreach (ItemCompra item in _itens)

                {

                    vTotal += item.CalcularSubtotal();

                }

                return vTotal;

                */

            }


            public void AdicionarItem(Produto produto, int quantidade)

            {

                if (produto == null) throw new Exception("Produto Inexistente");

                ItemCompra novoItem = new ItemCompra(produto.Id, quantidade, produto.Preco);

                this._itens.Add(novoItem);

            }


            public void RemoverItem(ItemCompra item)

            {

                this._itens.Remove(item);

            }


            public static int Inserir(Compra compra)

            {

                if (compra._clienteId <= 0) compra._clienteId = 10000;

                using (var cmd = new MySqlCommand("sp_InserirCompra"))

                {

                    cmd.Parameters.AddWithValue("p_DataHora", compra._dataHora);

                    cmd.Parameters.AddWithValue("p_FuncionarioId", compra._dataHora);

                    cmd.Parameters.AddWithValue("p_ClienteId", compra._clienteId);

                    object resultado = Banco.ExecutarComandoComRetornoId(cmd);

                    if (resultado != null && int.TryParse(resultado.ToString(), out int idGerado))

                    {

                        compra.Id = idGerado;

                        return idGerado;

                    }

                    return -1;

                }

            }

        }
}