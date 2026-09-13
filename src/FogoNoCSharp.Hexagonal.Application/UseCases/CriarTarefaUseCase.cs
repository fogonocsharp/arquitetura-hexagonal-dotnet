using FogoNoCSharp.Hexagonal.Application.Commands;
using FogoNoCSharp.Hexagonal.Application.Ports.Inbound;
using FogoNoCSharp.Hexagonal.Application.Ports.Outbound;
using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Application.UseCases;

public sealed class CriarTarefaUseCase : ICriarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public CriarTarefaUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<Guid> ExecutarAsync(CriarTarefaCommand command, CancellationToken cancellationToken = default)
    {
        var tarefa = new Tarefa(command.Titulo);

        await _tarefaRepository.AdicionarAsync(tarefa, cancellationToken);

        return tarefa.Id;
    }
}
