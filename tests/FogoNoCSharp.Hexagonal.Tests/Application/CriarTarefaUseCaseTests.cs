using FogoNoCSharp.Hexagonal.Application.Commands;
using FogoNoCSharp.Hexagonal.Application.UseCases;

namespace FogoNoCSharp.Hexagonal.Tests.Application;

public class CriarTarefaUseCaseTests
{
    [Fact]
    public async Task Executar_persiste_a_tarefa_e_devolve_o_id()
    {
        var repositorio = new TarefaRepositoryFake();
        var useCase = new CriarTarefaUseCase(repositorio);

        var id = await useCase.ExecutarAsync(new CriarTarefaCommand("Gravar o primeiro vídeo do Fogo no C#"));

        var tarefa = Assert.Single(repositorio.Tarefas);
        Assert.Equal(id, tarefa.Id);
        Assert.Equal("Gravar o primeiro vídeo do Fogo no C#", tarefa.Titulo);
    }
}
