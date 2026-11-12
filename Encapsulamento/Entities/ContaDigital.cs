public class ContaDigital
{
    public Cliente Titular { get; }
    public string NumeroConta { get; }
    public decimal Saldo { get; private set; }
    public bool EstaAtiva { get; private set; }

    public string Situacao => EstaAtiva ? "Ativa" : "Bloqueada";

    public ContaDigital(Cliente titular, string numeroConta)
    {
        if (string.IsNullOrWhiteSpace(numeroConta))
        {
            throw new ArgumentException("O número da conta deve ser informado.");
        }

        if(titular == null)
        {
            throw new ArgumentNullException("O cliente deve ser informado.");
        }

        Titular = titular;
        NumeroConta = numeroConta;
        Saldo = 0;
        EstaAtiva = true;
    }

    public void Depositar(decimal valor)
    {
        if(!EstaAtiva)
        {
            Console.WriteLine("Não é possível fazer depósito em conta bloqueada.");
            return;
        }

        if(valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser maior que zero.");
            return;
        }

        Saldo += valor;

        Console.WriteLine($"Depósito de {valor:C} realizado com sucesso.");
    }


    public void Sacar(decimal valor, string senhaInformada)
    {
        if(!EstaAtiva)
        {
            Console.WriteLine("Não é possível fazer saque em conta bloqueada.");
            return;
        }

        if(!Titular.ValidarSenha(senhaInformada))
        {
            Console.WriteLine("Senha incorreta");
            return;
        }

        if(valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser maior do que zero.");
            return;
        }

        if(valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
            return;
        }

        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:C} realizado com sucesso.");

    }

    public void BloquearConta(string senhaInformada)
    {
        if(!Titular.ValidarSenha(senhaInformada))
        {
            Console.WriteLine("Senha incorreta.");
            return;
        }

        if(!EstaAtiva)
        {
            Console.WriteLine("A conta já está bloqueada.");
            return;
        }

        EstaAtiva = false;
        Console.WriteLine("Conta bloqueada com sucesso.");
    }

    public void DesbloquearConta(string senhaInformada)
    {
        if(!Titular.ValidarSenha(senhaInformada))
        {
            Console.WriteLine("Senha incorreta.");
            return;
        }

        if(EstaAtiva)
        {
            Console.WriteLine("A conta já está ativa.");
            return;
        }

        EstaAtiva = false;
        Console.WriteLine("Conta ativada com sucesso.");
    }
}