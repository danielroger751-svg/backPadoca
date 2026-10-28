using backPadoca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Services
{
    internal class ClienteServices
    {
        public static class ClienteService
        {

            public static void MenuCliente()
            {
                bool sair = false;

                while (!sair)
                {
                    Console.WriteLine("===== GESTÃO DE CLIENTES =====");

                    Console.WriteLine("1 - Cadastrar Cliente");
                    Console.WriteLine("2 - Listar Todos os Clientes");
                    Console.WriteLine("3 - Buscar Cliente por ID");
                    Console.WriteLine("4 - Atualizar Cliente");
                    Console.WriteLine("5 - Excluir Cliente");
                    Console.WriteLine("6 - Visualizar pontuação");
                    Console.WriteLine("0 - Sair do Programa");

                    Console.WriteLine("======================");
                    Console.WriteLine("Digite uma opção: ");

                    string opcao = Console.ReadLine();

                    Console.Clear();

                    try
                    {
                        switch (opcao)
                        {
                            case "1": // Cadastrar

                                CadastrarClienteMenu();

                                break;

                            case "2": // Listar
                                listarClientesMenu();
                                break;
                            case "3":   // Buscar Por ID

                                BuscarPorID();

                                break;
                            case "4": // Atualizar Cliente

                                AtualizarCliente();

                                break;
                            case "5":// Excluir Cliente

                                ExcluirCliente();

                                break;
                            case "6": // Visualizar pontuação

                                VisualizarPontuação();

                                break;
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n[ERRO DE VALIDAÇÃO] : {ex.Message}");
                    }
                }
            }// Fim Menu

            private static void CadastrarClienteMenu()
            {

                Console.WriteLine(" ==---- CADASTRAR CLIENTE --- *");

                Console.WriteLine("Digite O Nome Do Cliente: ");
                string nomeCliente = Console.ReadLine();

                Console.WriteLine("Digite O Endereçe Do Cliente: ");
                string enderecoCliente = Console.ReadLine();

                Console.WriteLine("Digite O CPF Do Cliente: ");
                string cpfCliente = Console.ReadLine();

                Console.WriteLine("Digite O Telefone Do Cliente: *");
                string telefoneCliente = Console.ReadLine();

                Console.WriteLine("Digite A Quantidade De Pontos");
                int pontosCLiente = int.Parse(Console.ReadLine());


                Cliente NovoCliente = new Cliente(
                    nome: nomeCliente,
                    cpf: cpfCliente,
                    telefone: telefoneCliente,
                    endereco: enderecoCliente,
                    pontos: pontosCLiente
                    );

                int resultadoInsert = Cliente.inserir(NovoCliente);

                Console.Clear();

                if (resultadoInsert > 0) Console.WriteLine("Cliente Cadastrado Com Sucesso!!");
            }

            private static void listarClientesMenu()
            {
                Console.WriteLine("------ LISTA DE CLIENTES ------");

                List<Cliente> lista = Cliente.ListarTodos();

                if (lista.Count == 0)
                {

                    Console.WriteLine("Nenhum Cliente Cadastrado No Sitema");

                }
                else
                {
                    foreach (var cliente in lista)
                    {
                        Console.WriteLine($"ID: {cliente.Id} | Nome {cliente.Nome} | CPF: {cliente.Cpf}| Pontos: {cliente.Pontos}");
                    }
                }

                Console.WriteLine("\nPreicione uma tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            private static void BuscarPorID()
            {
                Console.WriteLine("======Buscar Cliente por ID======");

                Console.WriteLine("Digite o ID do cliente: ");
                try
                {
                    int id = int.Parse(Console.ReadLine());


                    Cliente cliente = Cliente.ListarPorID(id);

                    if (cliente == null)
                    {
                        Console.WriteLine($"\nCliente com ID {id} não encontrado.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        return;
                    }

                    Console.WriteLine($"ID: {cliente.Id}");
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"CPF: {cliente.Cpf}");
                    Console.WriteLine($"Telefone: {cliente.Telefone}");
                    Console.WriteLine("Precione Qualquer Tecla Para Encerrar! ");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valor inválido");
                    Thread.Sleep(2000);
                    Console.Clear();

                } 
            }


            private static void AtualizarCliente()
            {
                Console.WriteLine("======Atualizar por ID=======");
                Console.WriteLine("Digite O Nome Que Deseja Atualizar: ");
                string NovoNome = Console.ReadLine();

                Console.WriteLine("Digite O Telefone Que Deseja Atualizar: ");
                int.TryParse(Console.ReadLine(), out int NovoTelefone);

                Console.WriteLine("Digite O Endereço Que Deseja Atualizar: ");
                string enderecoCliente = Console.ReadLine();

                Console.WriteLine("Precione Qualquer Tecla Para Encerrar! ");
                Console.ReadKey();
                Console.Clear();
            }

            private static void ExcluirCliente()
            {
                Console.WriteLine("====== Excluindo Cliente ======");
                Console.WriteLine("Digite O ID que deseja Excluir:");
                int idBusca = 0;
                int.TryParse(Console.ReadLine(), out idBusca);

                Cliente? clienteParaExcluir = Cliente.ListarPorID(idBusca);

                if (idBusca != 0)
                {
                    Cliente.Deletar(clienteParaExcluir);
                    Console.WriteLine("Exluido Com Sucesso! ");
                }
                else
                {
                    Console.WriteLine("ID Não Encontrado! ");
                    Console.WriteLine("Precione Qualquer Tecla Para Encerrar! ");
                }
                Console.ReadKey();
            }

            private static void VisualizarPontuação()
            {
                Console.WriteLine("====== Visualizar Pontuação ======");
                Console.WriteLine("Digite O ID Para Visualizar Sua Pontuação: ");
                int.TryParse(Console.ReadLine(), out int idVisualizar);
                if (idVisualizar != 0)
                {
                    Cliente? clienteParabusca = Cliente.ListarPorID(idVisualizar);
                    Console.WriteLine("Vizualização Concluida! ");
                }
                else
                {
                    Console.WriteLine("id Não Encntrado! ");
                    Console.ReadKey();
                }

            }

        }
    }
}




