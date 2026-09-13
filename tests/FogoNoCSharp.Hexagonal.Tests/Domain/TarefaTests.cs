using FogoNoCSharp.Hexagonal.Domain.Entities;

namespace FogoNoCSharp.Hexagonal.Tests.Domain;

public class TarefaTests
{
    [Fact]
    public void Nova_tarefa_nasce_identificada_datada_e_nao_concluida()
    {
        var tarefa = new Tarefa("Gravar vídeo sobre arquitetura hexagonal");

        Assert.NotEqual(Guid.Empty, tarefa.Id);
        Assert.Equal("Gravar vídeo sobre arquitetura hexagonal", tarefa.Titulo);
        Assert.False(tarefa.Concluida);
        Assert.NotEqual(default, tarefa.CriadaEm);
    }

    [Fact]
    public void Concluir_marca_a_tarefa_como_concluida()
    {
        var tarefa = new Tarefa("Gravar vídeo sobre arquitetura hexagonal");

        tarefa.Concluir();

        Assert.True(tarefa.Concluida);
    }

    [Fact]
    public void Titulo_vazio_nao_e_aceito()
    {
        Assert.Throws<ArgumentException>(() => new Tarefa("   "));
    }
}
