internal class Carro : Veiculo
{
    public int QuantidadePortas { get; }
    public bool PossuiArCondicionado { get; }

     public Carro(string placa, string modelo, decimal valorDiaria, int qtddPortas, bool possuiArCondicionado )
      : base(placa, modelo, valorDiaria)
    {
        QuantidadePortas = qtddPortas;
        PossuiArCondicionado = possuiArCondicionado;
    }

    public override decimal CalcularValorLocacao(int qtddDias)
    {
        decimal valorBase =  base.CalcularValorLocacao(qtddDias);

        if(PossuiArCondicionado)
        {
            return valorBase * 1.1m;
        }

        return valorBase;
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();

        Console.WriteLine($"Quantidade de portas: {QuantidadePortas}");
        Console.WriteLine($"Possui ar condiiconado: {(PossuiArCondicionado ? "Sim" : "Não")}");
    }
}