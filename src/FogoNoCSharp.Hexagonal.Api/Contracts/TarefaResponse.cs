using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Api.Contracts;

public sealed record TarefaResponse(Guid Id, string Titulo, bool Concluida, DateTime CriadaEm)
{
    public static TarefaResponse De(Tarefa tarefa)
        => new(tarefa.Id, tarefa.Titulo, tarefa.Concluida, tarefa.CriadaEm);
}
