using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Services
{
    internal class VendaService
    {

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

            // 1 




        }



    }
}
