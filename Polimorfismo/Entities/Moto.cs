internal class Moto : Veiculo
{
    public int Cilindradas { get; }

    public Moto(string placa, string modelo, decimal valorDiaria, int cilindradas)
      : base(placa, modelo, valorDiaria)

    {
        Cilindradas = cilindradas;
    }

    public override decimal CalcularValorLocacao(int qtddDias)
    {
        var valorBase =  base.CalcularValorLocacao(qtddDias);

        if(Cilindradas >= 500)
        {
            return valorBase * 1.15m;
        }

        return valorBase;
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Cilindradas: {Cilindradas}");
    }
}