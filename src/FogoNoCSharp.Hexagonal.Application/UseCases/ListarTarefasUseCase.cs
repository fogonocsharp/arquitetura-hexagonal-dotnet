using FogoNoCSharp.Hexagonal.Application.Ports.Inbound;
using FogoNoCSharp.Hexagonal.Application.Ports.Outbound;
using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Application.UseCases;

public sealed class ListarTarefasUseCase : IListarTarefasUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public ListarTarefasUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public Task<IReadOnlyCollection<Tarefa>> ExecutarAsync(CancellationToken cancellationToken = default)
        => _tarefaRepository.ObterTodasAsync(cancellationToken);
}
