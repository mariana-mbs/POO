List<Cliente> clientes = new List<Cliente>()
{
    new Cliente(1, "Mariana"),
    new Cliente(2, "Lucas"),
    new Cliente(3, "Martim")
};

List<Veiculo> frota = new List<Veiculo>()
{
    new Carro("ABC-1234", "Honda Civic", 250, 4, true),
    new Carro("DEF-2345", "Renault Kwid", 150, 4, false),
    new Moto("GHI-3456", "Honda CG 160", 100, 160),
    new Moto("JKL-4567", "Honda CB 650R", 300, 650),
    new Caminhao("MNO-5678", "Volvo VM", 700, 8)
};

List<Locacao> locacoes = new List<Locacao>();
int proximoIdLocacao = 1;
bool continuar = true;

while (continuar)
{
    Console.WriteLine("******SISTEMA DE LOCAÇÃO DE FROTA*******");
    Console.WriteLine();
    Console.WriteLine("1 - Consultar frota");
    Console.WriteLine("2 - Consultar clientes");
    Console.WriteLine("3 - Calcular cotação");
    Console.WriteLine("4 - Registrar locação");
    Console.WriteLine("5 - Registrar devolução");
    Console.WriteLine("6 - Consultar locações");
    Console.WriteLine("7 - Alterar valor da diária");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("*********************");
    Console.WriteLine();

    Console.WriteLine("Escolha uma opção:");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
        ConsultarFrota(frota);
        break;
        case "2":
        ConsultarClientes(clientes);
        break;
        case "3":
        CalcularCotacao(frota);
        break;
        case "4":
        RegistrarLocacao(clientes, frota, locacoes, ref proximoIdLocacao);
        break;
        case "5":
        RegistrarDevolucao(locacoes);
        break;
        case "6":
        ConsultarLocacoes(locacoes);
        break;
        case "7":   
        AlterarValorDiaria(frota);
        break;
        case "0":
        continuar = false;
        break;
        default:
        Console.WriteLine("Opção inválida.");
        break;
    }
}

static void ConsultarFrota(List<Veiculo> frota)
{
    Console.WriteLine("-- Frota da locadora --");

    foreach (var veiculo in frota)
    {
        veiculo.ExibirInformacoes();
        Console.WriteLine();
    }
}

static void ConsultarClientes(List<Cliente> clientes)
{
   Console.WriteLine("--Clientes--");

   foreach (Cliente cliente in clientes)
   {
        Console.WriteLine($"{cliente.Id} - {cliente.Nome}");
   } 
   Console.WriteLine();
}

static void CalcularCotacao(List<Veiculo> frota)
{
    Console.WriteLine("-- Cotação de locação --");
    Console.WriteLine("Informe a quantidade de dias:");

    if(!int.TryParse(Console.ReadLine(), out var qtddDias))
    {
        Console.WriteLine("Quantidade de dias inválida");
        return;
    }

    var veiculo = BuscarVeiculoPorPlaca(frota);

    if(veiculo is null) return;

    try
    {
        decimal valor = veiculo.CalcularValorLocacao(qtddDias);
        Console.WriteLine("");
        Console.WriteLine($"Veiculo: {veiculo.Modelo}");
        Console.WriteLine($"Placa: {veiculo.Placa}");
        Console.WriteLine($"Período: {qtddDias} dias");
        Console.WriteLine($"Valor: {valor:C}");
    }
    catch (System.Exception ex)
    {
        
        Console.WriteLine(ex.Message);
    }

}

static Veiculo BuscarVeiculoPorPlaca(List<Veiculo> frota)
{
    Console.WriteLine("Informe a placa do veículo");
    var placa = Console.ReadLine();

    var veiculo = frota.FirstOrDefault(x => x.Placa.Trim().ToUpper() == placa.Trim().ToUpper());

    if(veiculo is null)
    {
        Console.WriteLine($"Nenhum veículo encontrado com a placa {placa}");
    }

    return veiculo;
}

static void RegistrarLocacao(List<Cliente> clientes, List<Veiculo> frota, List<Locacao> locacoes, ref int proximoIdLocacao)
{
    Console.WriteLine("--- Nova Locação ---");

    var veiculo = BuscarVeiculoPorPlaca(frota);
    if (veiculo is null) return;

    Console.WriteLine("Informe o id do cliente:");

    if(!int.TryParse(Console.ReadLine(), out int idCliente))
    {
        Console.WriteLine("Id de cliente inválido.");
        return;
    }

    var cliente = clientes.FirstOrDefault(x => x.Id == idCliente);

    if(cliente is null)
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }

    Console.WriteLine("Informe a data de retirada:");

    if(!DateTime.TryParse(Console.ReadLine(), out DateTime dataRetirada))
    {
        Console.WriteLine("Data de retirada inválida");
        return;
    }

    Console.WriteLine("Informe a quantidade de dias:");

    if(!int.TryParse(Console.ReadLine(), out var qtddDias))
    {
        Console.WriteLine("Quantidade de dias inválida.");
        return;
    }

    try
    {
        var locacao = new Locacao(proximoIdLocacao, cliente, veiculo, dataRetirada, qtddDias);
        locacoes.Add(locacao);
        proximoIdLocacao++;
        Console.WriteLine("Locação registrada com sucesso");

        locacao.ExibirInformacoes();
    }
    catch (System.Exception ex)
    {
        
        Console.WriteLine(ex.Message);
    }
}

static void RegistrarDevolucao(List<Locacao> locacoes)
{
    Console.WriteLine(("--- Devolver veículo ---"));

    if (locacoes.Count == 0)
    {
        Console.WriteLine("Nenhuma locação foi regustrada.");
        return;
    }

    Console.WriteLine("Informe o Id de locação:");
    if (!int.TryParse(Console.ReadLine(), out int idLocacao))
    {
        Console.WriteLine("Id de locação inválido.");
    }

    var locacao = locacoes.FirstOrDefault(x => x.Id == idLocacao);
    if (locacao == null)
    {
        Console.WriteLine("Locação não encontrada");
        return;
    }

    locacao.Devolver();
    Console.WriteLine("Veículo devolvido com sucesso.");
}

static void ConsultarLocacoes(List<Locacao> locacoes)
{
    if (locacoes.Count == 0)
    {
        Console.WriteLine("Nenhuma locação foi registrada");
    }

    foreach (var locacao in locacoes)
    {
        locacao.ExibirInformacoes();
        Console.WriteLine();   
    }
}

static void AlterarValorDiaria(List<Veiculo> frota)
{
    Console.WriteLine("--- Alterar valor da diária ---");

    var veiculo = BuscarVeiculoPorPlaca(frota);
    if (veiculo is null)return;

    Console.WriteLine($"Valor da diária atual: {veiculo.ValorDiaria}");
    Console.WriteLine("Informe o novo valor da diária:");

    if(!decimal.TryParse(Console.ReadLine(), out decimal novoValor))
    {
        Console.WriteLine("Valor inválido");
        return;
    }

    if(veiculo.AlterarValorDiaria(novoValor))
    {
        Console.WriteLine("Valor alterado com sucesso.");
    }
    else
    Console.WriteLine("Erro ao alterar valor.");

}