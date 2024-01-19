using ECommerce.Domain;
using ECommerce.Domain.Carrinho;
using MediatR;

namespace ECommerce.Application.UseCases.Carrinho.AdicionarItemAoPedido;

public class AdicionarItemAoPedidoHandler(IMediator mediator,
    IPedidoReadOnlyRepository pedidoReadOnlyRepository,
    IPedidoWriteOnlyRepository pedidoWriteOnlyRepository,
    IProdutoReadOnlyRepository produtoRepository
    )
    : IRequestHandler<AdicionarItemAoPedidoCommand, Result<AdicionarItemAoPedidoResult>>
{
    public async Task<Result<AdicionarItemAoPedidoResult>> Handle(AdicionarItemAoPedidoCommand request,
        CancellationToken cancellationToken)
    {
        var pedidoResult = await pedidoReadOnlyRepository.ObterPorId(request.IdDoPedido, cancellationToken);
        if (pedidoResult.Status != ResultStatus.Success)
            return Result<AdicionarItemAoPedidoResult>.EntityNotFound("Pedido", request.IdDoPedido, "Pedido não encontrado");
        
        var produtoResult = await produtoRepository.ObterPorId(request.IdDoItem, cancellationToken);
        if (produtoResult.Status != ResultStatus.Success)
            return Result<AdicionarItemAoPedidoResult>.EntityNotFound("Produto", request.IdDoItem, "Produto não encontrado");
        
        var pedido = pedidoResult.Data!;
        var produto = produtoResult.Data!;

        var pedidoAlterado = pedido.AdicionarItens(
            new ItemPedido(produto.Id, request.Quantidade, produto.Preco)
            );

        var result = await pedidoWriteOnlyRepository.AtualizaPedido(pedidoAlterado, cancellationToken);
        if (result.Status != ResultStatus.Success) throw new Exception("Erro ao adicionar item ao pedido");
        
        _ = mediator.Publish(new ItemAdicionadoAoPedidoNotification(pedido.Id, produto.Id), cancellationToken);
        return new AdicionarItemAoPedidoResult(pedido.Id);
    }
}