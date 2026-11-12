internal class Gerente : Funcionario
{
    public string Setor { get; set; }
    public int QtdPessoasEquipe { get; set; }

    public Gerente(string nome, string cpf, decimal salario, string setor, int qtdPessoasEquipe) : base(nome, cpf, salario)
    {
        Setor = setor;
        QtdPessoasEquipe = qtdPessoasEquipe;
    }

    public void RealizarReunioes()
    {
        Console.WriteLine($"O gerente {Nome} está em reunião com sua equipe do setor {Setor}.");
    }

    public void ExibirDadosGerente()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Setor: {Setor}");
        Console.WriteLine($"Quantidade de pessoas na equipe: {QtdPessoasEquipe}");
    }
}