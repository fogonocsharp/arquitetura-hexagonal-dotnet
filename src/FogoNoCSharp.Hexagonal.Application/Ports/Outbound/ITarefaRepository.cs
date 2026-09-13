using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Application.Ports.Outbound;

/// <summary>
/// Output Port: o que a aplicação precisa do mundo externo.
/// Quem implementa é a infraestrutura, não a aplicação.
/// </summary>
public interface ITarefaRepository
{
    Task AdicionarAsync(Tarefa tarefa, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Tarefa>> ObterTodasAsync(CancellationToken cancellationToken = default);
}
