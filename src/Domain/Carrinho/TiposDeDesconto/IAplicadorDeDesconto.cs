namespace ECommerce.Domain.Carrinho.TiposDeDesconto;

public interface IAplicadorDeDesconto
{
    decimal AplicarDesconto(Pedido pedido, decimal valorInicialDoDesconto);
}

public class LimiteDeDescontoPorItens : IAplicadorDeDesconto
{
    public decimal AplicarDesconto(Pedido pedido, decimal valorInicialDoDesconto)
        => pedido.Itens.Count switch
        {
            > 5 => 15,
            < 3 => 10,
            _ => valorInicialDoDesconto
        };
}
