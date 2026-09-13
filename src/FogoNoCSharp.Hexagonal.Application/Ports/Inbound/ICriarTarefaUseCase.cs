using FogoNoCSharp.Hexagonal.Application.Commands;

namespace FogoNoCSharp.Hexagonal.Application.Ports.Inbound;

/// <summary>
/// Input Port: o que o mundo externo pode pedir para a aplicação fazer.
/// </summary>
public interface ICriarTarefaUseCase
{
    Task<Guid> ExecutarAsync(CriarTarefaCommand command, CancellationToken cancellationToken = default);
}
