var gerente = new Gerente("Cynthia", "12345678901", 50000, "Diretoria", 20);
var dev = new Desenvolvedor("Mariana", "10987654321", 1600, "C#", "Estagiária");

Console.WriteLine("Dados do dev:");
dev.RegistrarEntrada();
dev.DesenvolverFuncionalidade();
dev.ExibirDadosDesenvolvedor();

Console.WriteLine();

Console.WriteLine("Dados do gerente:");
gerente.RegistrarEntrada();
gerente.RealizarReunioes();
gerente.ExibirDadosGerente();
