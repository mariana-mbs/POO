using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

List<Cliente> clientes = new List<Cliente>();
List<ContaDigital> contasDigitais = new List<ContaDigital>();

string opcao;

do
{
    Console.WriteLine();
    Console.WriteLine(" === Sistema de Conta Digital === ");
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar cliente: ");
    Console.WriteLine("2 - Cadastrar conta digital: ");
    Console.WriteLine("3 - Depósito: ");
    Console.WriteLine("4 - Saque: ");
    Console.WriteLine("5 - Bloquear conta");
    Console.WriteLine("6 - Desbloquear conta");
    Console.WriteLine();

    Console.WriteLine("Escolha uma opção:");
    opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
            CadastrarCliente(clientes);
            break;
        case "2":
            CadastrarConta(clientes, contasDigitais);
            break;
        case "3":
            Depositar(contasDigitais);
            break;
        case "4":
            Sacar(contasDigitais);
            break;
        case "5":
            BloquearConta(contasDigitais);
            break;
        case "6":
            DesbloquearConta(contasDigitais);
            break;
        default:
            Console.WriteLine("Opção de menu inválida.");
            break;

    }

} while (opcao != "0");

static void CadastrarCliente(List<Cliente> clientes)
{
    Console.WriteLine(" ** Cadastro de Cliente ** ");
    Console.WriteLine("Informe o nome: ");
    string nome = Console.ReadLine();

    Console.WriteLine("Informe o CPF: ");
    string cpf = Console.ReadLine();

    Console.WriteLine("Informe uma senha com 4 dígitos: ");
    string senha = Console.ReadLine();

    if(clientes.Any(x => x.CPF == cpf))
    {
        Console.WriteLine($"Já existe um cliente cadastrado com o CPF {cpf}");
        return;
    }
    
    try
    {
        Cliente cliente = new Cliente(nome, cpf, senha);
        clientes.Add(cliente);
        Console.WriteLine("Cliente cadastrado com sucesso.");   
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void CadastrarConta(List<Cliente> clientes, List<ContaDigital> contasDigitais)

{
    if(clientes.Count == 0)
    {
        Console.WriteLine("Cadastre o cliente antes de criar uma conta.");
        return;
    }

    Console.WriteLine(" ** Cadastro de Conta ** ");
    Console.WriteLine();
    Console.WriteLine("Informe o CPF do titular da conta: ");
    var cpf = Console.ReadLine();

    var cliente = clientes.Find(x => x.CPF == cpf);

    if(cliente == null)
    {
        Console.WriteLine("Cliente não encontrado.");
    }

    Console.WriteLine("Informe o número da conta: ");
    var conta = Console.ReadLine();

    if(contasDigitais.Any(x => x.NumeroConta == conta))
    {
        Console.WriteLine($"Já existe uma conta com o número {conta}.");
    }

    try
    {
        ContaDigital contaDigital = new ContaDigital(cliente, conta);
        contasDigitais.Add(contaDigital);
        Console.WriteLine("Conta criada com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}

static void Depositar(List<ContaDigital> contasDigitais)

{
    var conta = BuscarConta(contasDigitais);

    if(conta == null)
    {
        return;
    }

    Console.WriteLine("Informe o valor a ser depositado.");
    var valorDigitado = Console.ReadLine();

    if(!decimal.TryParse(valorDigitado, out decimal valor))
    {
        Console.WriteLine("Valor inválido.");
        return;
    }

    conta.Depositar(valor);
}

static void Sacar(List<ContaDigital> contasDigitais)
{
    var conta = BuscarConta(contasDigitais);

    if(conta == null)
        return;

    Console.WriteLine("Informe o valor do saque.");
    var valorDigitado = Console.ReadLine();

    if(!decimal.TryParse(valorDigitado, out decimal valor))
    {
        Console.WriteLine("Valor inválido.");
        return;
    }

    Console.WriteLine("Informe a senha da conta:");
    var senha = Console.ReadLine();

    conta.Sacar(valor, senha);
}

static ContaDigital BuscarConta(List<ContaDigital> contasDigitais)

{
    Console.WriteLine("Imforme a conta: ");
    var contaInformada = Console.ReadLine();

    var conta = contasDigitais.Find(x => x.NumeroConta == contaInformada);

    if(conta == null)
    {
        Console.WriteLine("Conta não encontrada.");
    }

    return conta;
}

static void BloquearConta(List<ContaDigital> contasDigitais)
{
    var conta = BuscarConta(contasDigitais);

    if (conta == null)
    return;

    Console.WriteLine("Infrome a senha da conta:");
    var senha = Console.ReadLine();

    conta.BloquearConta(senha);
}

static void DesbloquearConta(List<ContaDigital> contasDigitais)
{
    var conta = BuscarConta(contasDigitais);

    if (conta == null)
    return;

    Console.WriteLine("Infrome a senha da conta:");
    var senha = Console.ReadLine();

    conta.DesbloquearConta(senha);
}