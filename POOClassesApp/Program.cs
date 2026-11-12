using ModuloPOO.Classes;

Funcionario func1 = new Funcionario("Mariana Machado", "Estagiaria", 1500);
Funcionario func2 = new Funcionario("Cynthia", "CEO", 50000);

var vh = func1.CalcularValorHora();
func1.RegistrarHoras(200);
func1.AumentarSalario(10);

func2.RegistrarHoras(300);
func2.AumentarSalario(50);

func1.ExibirInformacoes();
func2.ExibirInformacoes();
