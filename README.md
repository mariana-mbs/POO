# Estudos de POO em C#

Repositório com projetos de console desenvolvidos durante meus estudos de Programação Orientada a Objetos (POO) com C# e .NET.

Cada pasta contém um projeto independente. A solução `POO.slnx` reúne os projetos.

## Projetos

- **POOClassesApp** — prática com classes, propriedades, construtores e métodos usando a classe `Funcionario`.
- **POOHeranca** — prática de herança com funcionários, gerentes e desenvolvedores.
- **Encapsulamento** — sistema de conta digital com cadastro de clientes e contas, depósitos, saques e bloqueio de contas.
- **Polimorfismo** — sistema de locação de veículos (carros, motos e caminhões), com consultas, cotações, locações e devoluções.

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Como executar

No terminal, na raiz do repositório, execute o comando do projeto que deseja abrir:

```bash
dotnet run --project POOClassesApp/POOClassesApp.csproj
dotnet run --project POOHeranca/POOHeranca.csproj
dotnet run --project Encapsulamento/Encapsulamento.csproj
dotnet run --project Polimorfismo/Polimorfismo.csproj