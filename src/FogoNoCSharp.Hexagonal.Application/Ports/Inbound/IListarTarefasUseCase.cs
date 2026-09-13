using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Application.Ports.Inbound;

/// <summary>
/// Input Port: o que o mundo externo pode pedir para a aplicação fazer.
/// </summary>
public interface IListarTarefasUseCase
{
    Task<IReadOnlyCollection<Tarefa>> ExecutarAsync(CancellationToken cancellationToken = default);
}
