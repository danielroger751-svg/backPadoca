using backPadaria.Model;
using backPadoca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Services
{
    internal class VendaService
    {
        private static int idCliente;
        private static int funcionarioid;
        private static object compraAtiva;

        public static object ClienteVenda { get; private set; }

        public static void MenuVenda()
        {
            // 
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("======PDV - Padaria Pão & Cia ======");
                Console.WriteLine("1 - Iniciar Nova Venda");
                Console.WriteLine("0 - Voltar Ao Menu Principal");
                Console.WriteLine("====================================");
                Console.WriteLine("Digite Uma Opção: ");
                string opcao = Console.ReadLine();
                Console.Clear();


                try
                {
                    switch(opcao)
                    {
                        case "1":
                            iniciarNovaVenda();
                        break;

                        case "0":
                            sair = true;
                        break;

                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro na venda {ex.Message}  ");
                    Console.WriteLine("\nPrecione uma tecla para continuar...");
                    Console.ReadKey();
                }

            }

        }

        public static void iniciarNovaVenda()
        {
            Console.WriteLine("------ NOVA VENDA ------");

            // 1 - IDENTIFICAÇÃO DO FUNCIONÁRIO

            int funcionarioID = 2;

            // 1 - IDENTIFICAÇÃO

            Console.WriteLine("ID de cliente (Precione ENTER se não quiser Identificar");
            int.TryParse(Console.ReadLine(), out idCliente);
            Cliente? clientevenda = Cliente.listarPorId(idCliente);

            // -- Inicializando o objeto compra
            Compra compraAtiva = new Compra(DateTime.Now, funcionarioID, clientevenda.Id);

            // Loop De carrinho  de compras

            bool adicionarMais = true;

            while (adicionarMais)
            {
                Console.WriteLine("\n---Adicionar Produto ---");
                Console.WriteLine("Id do produto ou '0' para finalizar/pagar");

                int.TryParse(Console.ReadLine(), out int IdProduto);

                if (IdProduto == 0)
                {
                    adicionarMais = false;
                    continue;
                }

                Produto? produto = Produto.ListarPorId(IdProduto);
                if(produto == null)
                {
                    Console.WriteLine("Produto não encotrado... Tente Novamente!");
                    continue;
                }
                Console.Write($"Quantidade de {produto.Nome} Preço:|{produto.Preco:C}");
                int.TryParse(Console.ReadLine(), out int qtdProduto);
               
                if (qtdProduto >= 0)
                {
                    compraAtiva.AdicionarItem((produto, qtdProduto);
                    Console.WriteLine($"Subtotal: {produto.Preco * qtdProduto}");
                }
            } // ENCERRA O LAÇO DE PRODUTOS  

            // 3. Checkout
            if(compraAtiva.Itens.cout == 0)
            {
                Console.WriteLine("Venda Cancelada (Nenhumm Item Foi Adicionado).");
            }
            else
            {
                Console.WriteLine("\n------ RESUMO DA VENDA ------");
                foreach (var item in compraAtiva.Itens)
                {
                    Console.WriteLine($"ID: {item.produtoId}" + 
                        $"|Qtd: {item.Quantidade} " +
                        $"| Preço Unít: {item.PrecoCobrado} " +
                        $"| Subtotal: {item.CalcularTotal():C}");

                }
                decimal TotalFinal = compraAtiva.CalcularTotal();
                
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"TOTAL A PAGAR: {TotalFinal:C}");
                Console.WriteLine("-----------------------------");


            }
            Console.ReadKey();       


        }


    }
}
