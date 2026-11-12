using System.Security.Cryptography.X509Certificates;

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; }

    private string Senha;

    public Cliente(string nome, string cpf, string senha)
    {
        ValidarCamposObrigatorios(nome, cpf, senha);
        Nome = nome;
        CPF = cpf;
        Senha = senha;
    }

    private void ValidarCamposObrigatorios(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome deve ser informado.");
        }

        if (string.IsNullOrWhiteSpace(cpf) || cpf.Trim().Length != 11)
        {
            throw new ArgumentException("O CPF deve ser informado e possuir 11 dígitos.");
        }

        if (string.IsNullOrEmpty(senha) || senha.Trim().Length != 4)
        {
            throw new ArgumentException("A senha deve ser informada e possuir 4 dígitos");
        }
    }

    public bool ValidarSenha(string senhaInformada)
    {
        return Senha == senhaInformada;
    }

}