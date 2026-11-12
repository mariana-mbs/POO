internal class Locacao
{
    public int Id { get; }
    public Cliente Cliente { get; }
    public Veiculo Veiculo { get; }
    public DateTime DataRetirada { get; }
    public int QuantidadeDias { get; }
    public DateTime DataDevolucao { get; }
    public decimal ValorTotal { get; }
    public SituacaoLocacao Situacao { get; private set; }

    public Locacao(int id, Cliente cliente, Veiculo veiculo, DateTime dataRetirada, int qtddDias)
    {
        ValidacoaoDadosObrigatorios(id, cliente, veiculo, dataRetirada, qtddDias);
        Id = id;
        Cliente = cliente;
        Veiculo = veiculo;
        DataRetirada = dataRetirada;
        QuantidadeDias = qtddDias;
        DataDevolucao = dataRetirada.AddDays(qtddDias);
        Situacao = SituacaoLocacao.EmAndamento;
        ValorTotal = Veiculo.CalcularValorLocacao(qtddDias);

        Veiculo.TornarIndisponivel();
    }
    private void ValidacoaoDadosObrigatorios(int id, Cliente cliente, Veiculo veiculo, DateTime dataRetirada, int qtddDias)
    {

       if (id <= 0)
       {
        throw new ArgumentException("O id da locação deve ser maior do que zero.");
       } 

       if (cliente is null)
       {
        throw new ArgumentException("O cliente é obrigatório.");
       }

       if (veiculo is null)
       {
        throw new ArgumentException("O veículo não está disponível.");
       }

       if (!veiculo.Disponivel)
       {
        throw new ArgumentException("O veículo não está disponível");
       }

       if (qtddDias <= 0)
       {
        throw new ArgumentException("A quantidade de dias deve ser maior do que zero.");
       }
    }

    public void Devolver()
    {
        if (Situacao == SituacaoLocacao.Finalizada)
        {
            Console.WriteLine("Locação finalizada.");
            return;
        }

        Situacao = SituacaoLocacao.Finalizada;
        Veiculo.TornarDisponivel();
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Cliente: {Cliente.Id} - {Cliente.Nome}");
        Console.WriteLine($"Veículo: {Veiculo.Modelo}");
        Console.WriteLine($"Placa: {Veiculo.Placa}");
        Console.WriteLine($"Data de retirada: {DataRetirada:dd/MM/yyyy}");
        Console.WriteLine($"Devolução esperada: {DataDevolucao:dd/MM/yyyy}");
        Console.WriteLine($"Quantidade de dias: {QuantidadeDias}");
        Console.WriteLine($"Valor total: {ValorTotal:C}");
        Console.WriteLine($"Situação: {(Situacao == SituacaoLocacao.EmAndamento ? "Em andamento" : "Fianlizada")}");
    }

}
