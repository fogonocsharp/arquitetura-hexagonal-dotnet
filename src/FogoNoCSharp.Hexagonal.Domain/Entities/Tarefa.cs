namespace FogoNoCSharp.Hexagonal.Domain.Entities;

public sealed class Tarefa
{
    public Tarefa(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ArgumentException("O título da tarefa é obrigatório.", nameof(titulo));
        }

        Id = Guid.NewGuid();
        Titulo = titulo.Trim();
        Concluida = false;
        CriadaEm = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public string Titulo { get; }

    public bool Concluida { get; private set; }

    public DateTime CriadaEm { get; }

    public void Concluir() => Concluida = true;
}
