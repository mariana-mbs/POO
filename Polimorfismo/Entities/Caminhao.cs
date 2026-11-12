internal class Caminhao : Veiculo
{
    public int CapacidadeTonelada { get; }

    public Caminhao(string placa, string modelo, decimal valorDiaria, int capacidadeTonelada)
      : base(placa, modelo, valorDiaria)
    {
        CapacidadeTonelada = capacidadeTonelada;
    }

    public override decimal CalcularValorLocacao(int qtddDias)
    {
        var valorBase =  base.CalcularValorLocacao(qtddDias);

        decimal taxaCarga = 50 * CapacidadeTonelada * qtddDias;

        return valorBase + taxaCarga;
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Capacidade de carga: {CapacidadeTonelada} tonelada(s).");
    }
}