using ECommerce.Domain.Carrinho;

namespace ECommerce.UnitTests.Domain.Carrinho;

public class PedidoTests
{
    [Fact]
    public void Ao_Adicionar_Frete_Deve_Somar_Ao_Valor_Total()
    {
        // Arrange
        var pedido = Pedido.Criar(DateTime.Now, new Cliente(Guid.NewGuid(), Guid.NewGuid()));
        pedido.AdicionarItens(new ItemPedido(Guid.NewGuid(), 2, 30));
        var valorDoFrete = 10m;
        
        // Act
        var pedidoAlterado = pedido.AplicarValorDoFrete(valorDoFrete);
        
        // Assert
        Assert.Equal(70m, pedidoAlterado.ValorTotal);
    }
}