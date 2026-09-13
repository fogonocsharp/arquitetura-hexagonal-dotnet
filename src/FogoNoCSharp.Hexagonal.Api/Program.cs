using FogoNoCSharp.Hexagonal.Api.Contracts;
using FogoNoCSharp.Hexagonal.Application.Commands;
using FogoNoCSharp.Hexagonal.Application.Ports.Inbound;
using FogoNoCSharp.Hexagonal.Application.Ports.Outbound;
using FogoNoCSharp.Hexagonal.Application.UseCases;
using FogoNoCSharp.Hexagonal.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Composition Root: o único lugar que conhece as portas e os adapters ao mesmo tempo.

// Output Port -> Outbound Adapter.
// Singleton porque o armazenamento é em memória e precisa sobreviver entre as requisições.
builder.Services.AddSingleton<ITarefaRepository, TarefaRepositoryEmMemoria>();

// Input Ports -> Use Cases.
builder.Services.AddScoped<ICriarTarefaUseCase, CriarTarefaUseCase>();
builder.Services.AddScoped<IListarTarefasUseCase, ListarTarefasUseCase>();

var app = builder.Build();

// Inbound Adapter: traduz HTTP em chamadas às Input Ports.
app.MapPost("/tarefas", async (
    CriarTarefaRequest request,
    ICriarTarefaUseCase criarTarefaUseCase,
    CancellationToken cancellationToken) =>
{
    var id = await criarTarefaUseCase.ExecutarAsync(new CriarTarefaCommand(request.Titulo), cancellationToken);

    return Results.Json(new { id }, statusCode: StatusCodes.Status201Created);
});

app.MapGet("/tarefas", async (
    IListarTarefasUseCase listarTarefasUseCase,
    CancellationToken cancellationToken) =>
{
    var tarefas = await listarTarefasUseCase.ExecutarAsync(cancellationToken);

    return Results.Ok(tarefas.Select(TarefaResponse.De));
});

app.Run();
