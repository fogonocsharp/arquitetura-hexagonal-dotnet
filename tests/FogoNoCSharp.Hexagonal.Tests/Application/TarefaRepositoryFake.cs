using FogoNoCSharp.Hexagonal.Application.Ports.Outbound;
using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Tests.Application;

/// <summary>
/// Adapter de teste para a Output Port: substitui a infraestrutura sem mocks.
/// </summary>
internal sealed class TarefaRepositoryFake : ITarefaRepository
{
    public List<Tarefa> Tarefas { get; } = [];

    public Task AdicionarAsync(Tarefa tarefa, CancellationToken cancellationToken = default)
    {
        Tarefas.Add(tarefa);

        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Tarefa>> ObterTodasAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyCollection<Tarefa>>(Tarefas);
}
