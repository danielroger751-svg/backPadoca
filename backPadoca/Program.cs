using backPadaria.Model;
using backPadoca.Model;
using backPadoca.Services;
using static backPadoca.Services.ClienteServices;
namespace backPadoca
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /////////////////CLIENTE /////////////////////

            //Banco.connectAndTest();

            //Console.WriteLine("Digite o nome do cliente: ");
            //string nomeCliente = Console.ReadLine();

            //Console.WriteLine("Digite o cpf do cliente: ");
            //string cpfCliente = Console.ReadLine();

            //Console.WriteLine("Digite o telefone do cliente: ");
            //string telefoneCliente = Console.ReadLine();

            //Console.WriteLine("Digite a quantidade de pontos: ");
            //int qtdPontos = int.Parse(Console.ReadLine());


            //Cliente cliente1 = new Cliente(

            //    nome: nomeCliente,

            //    cpf: cpfCliente,

            //    telefone: telefoneCliente,

            //   endereco: enderecoCLiente,

            //   pontos: qtdPontos
            //);

            //Cliente.Inserir(cliente1);

            //Cliente clienteParaDeletar = new Cliente(3);
            //if (Cliente.Deletar(clienteParaDeletar) > 1)
            //{
            //    Console.WriteLine("Deu bom não.");
            //}
            //else
            //{
            //    Console.WriteLine("Cliente deletado com sucesso!");
            //}

            //List<Cliente> clientes = Cliente.ListarTodos();

            //foreach (Cliente cliente in clientes)
            //{
            //    Console.WriteLine("-------------------------");

            //    Console.WriteLine($"ID {cliente.Id}");

            //    Console.WriteLine($"Nome: {cliente.Nome}");

            //    Console.WriteLine($"CPF: {cliente.Cpf}");

            //    Console.WriteLine($"Telefone: {cliente.Telefone}");

            //    Console.WriteLine($"Endereço: {cliente.Endereco}");

            //    Console.WriteLine($"Pontos: {cliente.Pontos}");

            //    Console.WriteLine("-------------------------");
            //}

            //Cliente? cli01 = Cliente.listarPorId(2);
            //if (cli01 != null)
            //{
            //    Console.WriteLine("----------------");

            //    Console.WriteLine($"ID {cli01.Id}");

            //    Console.WriteLine($"Nome: {cli01.Nome}");

            //    Console.WriteLine($"CPF: {cli01.Cpf}");

            //    Console.WriteLine($"Telefone: {cli01.Telefone}");

            //    Console.WriteLine($"Endereço: {cli01.Endereco}");

            //    Console.WriteLine($"Pontos: {cli01.Pontos}");

            //    Console.WriteLine("--------------");
            //}

            //else
            //{
            //    Console.WriteLine("Cliente não foi encontrado.");
            //}
            //Cliente? meuCliente = Cliente.listarPorId(2);
            //if (meuCliente != null)
            //{
            //    meuCliente.Endereco = "Rua Barão de Alagoas, 171";

            //    meuCliente.Telefone = "1197747-8585";

            //    int resultado = Cliente.Atualizar(meuCliente);
            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Cliente atualizado com sucesso!");
            //    }


            //// FUNCIONARIO //////////////////////

            //Console.WriteLine("Digite o nome do funcionario: ");

            //string nomeFuncionario = Console.ReadLine();

            //Console.WriteLine("Digite o cpf do funcionario: ");

            //string cpfFuncionario = Console.ReadLine();

            //Console.WriteLine("Digite o Cargo do funcionario: ");

            //string cargoFuncionario = Console.ReadLine();

            //Funcionario funcionario1 = new Funcionario(

            //    Nome: nomeFuncionario,

            //    Cpf: cpfFuncionario,

            //    cargo: cargoFuncionario
            //    );

            //Funcionario.Inserir(funcionario1);

            //Funcionario funcionarioParaDeletar = new Funcionario(3);
            //if (Funcionario.Deletar(funcionarioParaDeletar) > 1)
            //{
            //    Console.WriteLine("Deu bom não.");
            //}
            //else
            //{
            //    Console.WriteLine("Cliente deletado com sucesso!");
            //}

            //List<Funcionario> funcionarios = Funcionario.ListarTodos();
            //foreach (Funcionario funcionario in uncionario)
            //{
            //    Console.WriteLine("-------------------------");

            //    Console.WriteLine($"ID {funcionario.Id}");

            //    Console.WriteLine($"Nome: {funcionario.Nome}");

            //    Console.WriteLine($"CPF: {funcionario.Cpf}");

            //    Console.WriteLine($"Cargo: {funcionario.Endereco}");

            //    Console.WriteLine("-------------------------");

            //    Funcionario? cli01 = Funcionario.listarPorId(2);
            //    if (cli01 != null)
            //    {
            //        Console.WriteLine("----------------");

            //        Console.WriteLine($"ID {cli01.Id}");

            //        Console.WriteLine($"Nome: {cli01.Nome}");

            //        Console.WriteLine($"CPF: {cli01.Cpf}");

            //        Console.WriteLine($"Cargo: {cli01.Cargo}");

            //        Console.WriteLine("--------------");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Funcionario não foi encontrado.");
            //    }

            //    Funcionario? meuFuncionario = Funcionario.listarPorId(2);
            //    if (meuFuncionario != null)
            //    {
            //        meuFuncionario.Cargo = "Atendimento";

            //        meuFuncionario.Cpf = "57977478585";

            //        int resultado = Funcionario.Atualizar(meuFuncionario);

            //        if (resultado > 0)
            //        {
            //            Console.WriteLine("Funcionario atualizado com sucesso!");
            //        }
            //}
            //}
            //        }


            //VendaService.MenuVenda();

            LoginFuncionario login = new LoginFuncionario(2, "jp_padoca@padariapaoecia.com.br", "deumaito", "Diretor");

            LoginFuncionario.Inserir(login);


        }
    }
}