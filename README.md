# ⚙️ Projeto CQRS com Padrão MediatR Personalizado

Este projeto simula o comportamento da biblioteca **MediatR** criando uma **implementação própria do padrão Mediator**, mantendo os princípios de CQRS e desacoplamento da lógica de aplicação.

---

## ✅ Funcionalidades

- ✅ CRUD básico de entidades com separação entre escrita e leitura
- ✅ Encaminhamento manual de comandos e queries para handlers via mediator customizado
- ✅ Estrutura modular e reutilizável
- ✅ Nenhuma dependência de bibliotecas externas como MediatR

---

## 🛠 Tecnologias Utilizadas

| Tecnologia        | Uso                                     |
|------------------|------------------------------------------|
| ASP.NET Core      | Web API backend                         |
| Entity Framework Core | ORM para banco de dados            |
| SQLite            | Banco de dados leve para testes locais  |
| AutoMapper        | Conversão entre DTOs e entidades        |
| Swagger           | Documentação da API                     |

---

## 📁 Estrutura do Projeto

```plaintext
CQRS-Mediator-Custom/
│
├── Core/
│   ├── Interfaces/
│   │   ├── ICommand.cs
│   │   ├── IQuery.cs
│   │   └── IMediator.cs
│   └── Mediator/
│       └── Mediator.cs
│
├── Application/
│   ├── Commands/
│   │   ├── CreateEntityCommand.cs
│   │   └── DeleteEntityCommand.cs
│   ├── Queries/
│   │   └── GetEntityQuery.cs
│   └── Handlers/
│       ├── CreateEntityHandler.cs
│       └── GetEntityHandler.cs
│
├── Domain/
│   └── Entities/
│
├── Infrastructure/
│   └── Repositories/
│
├── API/
│   └── Controllers/
│
└── Program.cs
```

---

## 🚀 Como Executar

1. Clone o projeto:
   ```bash
   git clone https://github.com/victorbiguete/MediatRManual
   ```

2. Navegue até o diretório:
   ```bash
   cd MediatRManual
   ```

3. Restaure e execute:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

---

## 🔎 Detalhes da Implementação

- **Mediator.cs**: Classe responsável por receber um comando ou consulta e encaminhá-lo ao handler correspondente.
- **Handlers**: Camada intermediária entre controller e domínio, responsável por executar a lógica específica.
- **Controller**: Totalmente desacoplado da lógica de negócio, chamando apenas `Mediator.Send(...)`.

---

## 🧠 Aprendizados

- Como funciona internamente a injeção de dependência e roteamento do MediatR
- Construção de um padrão flexível de mediação sem dependência de terceiros
- Aplicação prática de **CQRS** e **Clean Architecture**

---

## 👨‍💻 Autor

Desenvolvido por [Victor Biguete - Linkedln](https://www.linkedin.com/in/victorbiguete).
