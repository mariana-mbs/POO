internal class Funcionario
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public decimal Salario { get; set; }

    public Funcionario(string nome, string cpf, decimal salario)
    {
        Nome = nome;
        CPF = cpf;
        Salario = salario;
    }

    public void RegistrarEntrada()
    {
       Console.WriteLine($"{Nome} registrou entrada as {DateTime.Now:HH:mm}.");    
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine();
        Console.WriteLine(" === Funcionário === ");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Salário: {Salario:C}");
    }

}