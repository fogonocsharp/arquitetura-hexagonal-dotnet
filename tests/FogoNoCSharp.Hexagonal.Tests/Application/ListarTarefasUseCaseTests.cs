using FogoNoCSharp.Hexagonal.Application.UseCases;
using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Tests.Application;

public class ListarTarefasUseCaseTests
{
    [Fact]
    public async Task Executar_devolve_as_tarefas_do_repositorio()
    {
        var repositorio = new TarefaRepositoryFake();
        repositorio.Tarefas.Add(new Tarefa("Gravar o primeiro vídeo do Fogo no C#"));
        var useCase = new ListarTarefasUseCase(repositorio);

        var tarefas = await useCase.ExecutarAsync();

        var tarefa = Assert.Single(tarefas);
        Assert.Equal("Gravar o primeiro vídeo do Fogo no C#", tarefa.Titulo);
    }
}
