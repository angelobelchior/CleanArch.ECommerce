using ECommerce.Application.UseCases.Carrinho;
using ECommerce.Domain;
using ECommerce.Domain.Carrinho;

namespace ECommerce.Infrastructure.Repositories.Carrinho;

internal class PedidoRepository : IPedidoReadOnlyRepository, IPedidoWriteOnlyRepository 
{
    public Task<Result<Pedido>> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        var pedido = new Pedido(id, DateTime.Now, new Cliente(Guid.NewGuid(), Guid.NewGuid()));
        pedido.AdicionarItens(new ItemPedido(Guid.NewGuid(), 1, 50));
        
        return Task.FromResult(Result<Pedido>.Success(pedido));
    }

    public Task<Result> AtualizaPedido(Pedido pedido, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}