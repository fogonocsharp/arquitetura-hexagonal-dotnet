# Arquitetura Hexagonal em .NET

Projeto criado no Vídeo #001 do canal **Fogo no C#**.

Uma API mínima de tarefas, escrita para deixar visível o que realmente importa na
Arquitetura Hexagonal (Ports and Adapters): **a aplicação define aquilo que precisa e a
infraestrutura se adapta a ela**.

- **Domain** — a entidade `Tarefa` e suas regras. Não conhece HTTP, banco ou framework.
- **Application** — os casos de uso e as portas. É o centro do hexágono.
  - **Input Port** — o que o mundo externo pode pedir para a aplicação (`ICriarTarefaUseCase`, `IListarTarefasUseCase`).
  - **Output Port** — o que a aplicação precisa do mundo externo (`ITarefaRepository`).
- **Infrastructure** — os adapters que implementam as Output Ports (`TarefaRepositoryEmMemoria`).
- **Api** — o adapter de entrada (Minimal API) e o Composition Root.

```
HTTP
 |
 v
Inbound Adapter        (Minimal API)
 |
 v
Input Port             (ICriarTarefaUseCase / IListarTarefasUseCase)
 |
 v
Application / Use Case (CriarTarefaUseCase / ListarTarefasUseCase)
 |
 v
Output Port            (ITarefaRepository)
 |
 v
Outbound Adapter       (TarefaRepositoryEmMemoria)
 |
 v
Persistência
```

## Direção das dependências

```
Api  ->  Application  ->  Domain
 |            ^
 v            |
Infrastructure +
```

- `Domain` não referencia nenhum outro projeto.
- `Application` referencia apenas `Domain`.
- **`Application` NÃO depende de `Infrastructure`.** A infraestrutura é que depende da
  aplicação, porque é ela quem implementa as portas definidas pela aplicação.
- `Api` referencia `Application` e `Infrastructure` — é o único lugar que conhece as duas
  pontas, justamente porque é o Composition Root.

Por isso é possível trocar `TarefaRepositoryEmMemoria` por um `TarefaRepositoryEfCore`
sem tocar em uma linha dos casos de uso.

> Arquitetura Hexagonal não é estrutura de pastas. As pastas aqui ajudam a leitura, mas o
> que sustenta a arquitetura é a direção das dependências.

## Estrutura do projeto

```
FogoNoCSharp.Hexagonal.sln
src/
  FogoNoCSharp.Hexagonal.Domain/          Entidade Tarefa
  FogoNoCSharp.Hexagonal.Application/     Commands, Ports (Inbound/Outbound) e Use Cases
  FogoNoCSharp.Hexagonal.Infrastructure/  Outbound Adapter em memória
  FogoNoCSharp.Hexagonal.Api/             Minimal API + Composition Root
tests/
  FogoNoCSharp.Hexagonal.Tests/           Testes de Domain e Application
```

## Executando

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/FogoNoCSharp.Hexagonal.Api
```

A API sobe em `http://localhost:5295`.

## Endpoints

### POST /tarefas

```json
{
    "titulo": "Gravar o primeiro vídeo do Fogo no C#"
}
```

Resposta `201 Created`:

```json
{
    "id": "8f2a5e0c-6d0a-4a6f-9b3f-2a1c5d9e7b40"
}
```

### GET /tarefas

Resposta `200 OK`:

```json
[
    {
        "id": "8f2a5e0c-6d0a-4a6f-9b3f-2a1c5d9e7b40",
        "titulo": "Gravar o primeiro vídeo do Fogo no C#",
        "concluida": false,
        "criadaEm": "2026-01-01T12:00:00.0000000Z"
    }
]
```

Há também o arquivo `src/FogoNoCSharp.Hexagonal.Api/FogoNoCSharp.Hexagonal.Api.http` com as
duas chamadas prontas.

> O repositório é em memória e está registrado como **Singleton**, para que as tarefas
> criadas no `POST` continuem existindo no `GET` enquanto a aplicação estiver rodando.

## Vídeo

YouTube: em breve
