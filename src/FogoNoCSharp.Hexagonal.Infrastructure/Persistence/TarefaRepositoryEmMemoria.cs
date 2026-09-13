using System.Collections.Concurrent;
using FogoNoCSharp.Hexagonal.Application.Ports.Outbound;
using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Infrastructure.Persistence;

/// <summary>
/// Outbound Adapter: implementa a Output Port <see cref="ITarefaRepository"/>.
/// Trocar este adapter por um baseado em banco de dados não muda nenhum caso de uso.
/// </summary>
public sealed class TarefaRepositoryEmMemoria : ITarefaRepository
{
    private readonly ConcurrentDictionary<Guid, Tarefa> _tarefas = new();

    public Task AdicionarAsync(Tarefa tarefa, CancellationToken cancellationToken = default)
    {
        _tarefas[tarefa.Id] = tarefa;

        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Tarefa>> ObterTodasAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<Tarefa> tarefas = _tarefas.Values
            .OrderBy(tarefa => tarefa.CriadaEm)
            .ToArray();

        return Task.FromResult(tarefas);
    }
}
