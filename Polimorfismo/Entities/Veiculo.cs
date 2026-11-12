using System.Reflection.Metadata;

internal class Veiculo
{
    public string Placa { get; }
    public string Modelo { get; }
    public decimal ValorDiaria { get; private set; }
    public bool Disponivel { get; private set; }

    public Veiculo(string placa, string modelo, decimal valorDiaria)
    {
        Placa = placa;
        Modelo = modelo;
        ValorDiaria = valorDiaria;
        Disponivel = true;
    }

    public bool AlterarValorDiaria(decimal valorDiaria)
    {
        if(valorDiaria < 0)
        {
            return false;
        }

        ValorDiaria = valorDiaria;
        return true;
    }

    public void TornarIndisponivel()
    {
        Disponivel = false;
    }
     public void TornarDisponivel()
    {
        Disponivel = true;
    }

    public virtual decimal CalcularValorLocacao(int qtddDias)
    {
        if(qtddDias <= 0 )
        {
            throw new ArgumentException("A quantidade de dias deve ser maior que zero.");
        }

        return ValorDiaria * qtddDias;
    }

    public virtual void ExibirInformacoes()
    {
        Console.WriteLine("--------------");
        Console.WriteLine($"Categoria: {GetType().Name}");
        Console.WriteLine($"Placa: {Placa}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Valor da diária: {ValorDiaria:C}");
        Console.WriteLine($"Situação: {(Disponivel ? "Disponível" : "Alugado")}");
    }
}