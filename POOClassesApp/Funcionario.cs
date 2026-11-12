namespace ModuloPOO.Classes;
public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public int HorasTrabalhadas { get; set; }

    public Funcionario(string nome, string cargo, decimal salario)
    {
     Nome = nome;
     Cargo = cargo;
     Salario = salario;   
    }

    public void RegistrarHoras(int horas)
    {
        if(horas <= 0)
        {
            Console.WriteLine("A quantidade de horas deve ser maior do que 0.");
            return;
        }
        
        HorasTrabalhadas += horas;

        Console.WriteLine($"{horas} hora(s) registradas(s) para {Nome}");
    }

    public void AumentarSalario(decimal percentual)

    {
     if(percentual <= 0)
        {
            Console.WriteLine("O percentual deve ser maior do que 0");
            return;
        }
     
     decimal valorAumento = Salario * percentual / 100;
     Salario += valorAumento;

     Console.WriteLine($"O salário de {Nome} aumentado em {percentual}%");
     Console.WriteLine($"Salário atual: {Salario:C}");   

    }
    
    public decimal CalcularValorHora()
    {
        if(HorasTrabalhadas <= 0)
        {
            Console.WriteLine($"Não é possível calcular o valor da hora de {Nome} pois ainda não existem horas registradas.");
            return 0;
        }
        
        return Salario / HorasTrabalhadas;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine();
        Console.WriteLine(" === DADOS DO FUNCIONÁRIO ===");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário: {Salario:C}");
        Console.WriteLine($"Horas trabalhadas: {HorasTrabalhadas}");

        if (HorasTrabalhadas > 0)
        {
        Console.WriteLine($"Valor/hora: (CalcularValorHora)");
        }
        else
        {
            Console.WriteLine("Valor hora não disponível");
        }
    }


}