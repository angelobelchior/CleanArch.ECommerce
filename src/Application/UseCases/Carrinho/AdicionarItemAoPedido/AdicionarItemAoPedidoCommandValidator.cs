using FluentValidation;

namespace ECommerce.Application.UseCases.Carrinho.AdicionarItemAoPedido;

public class AdicionarItemAoPedidoCommandValidator : AbstractValidator<AdicionarItemAoPedidoCommand>
{
    public AdicionarItemAoPedidoCommandValidator()
    {
        RuleFor(x => x.IdDoPedido).NotEmpty().WithMessage("O id do pedido deve ser informado");
        RuleFor(x => x.IdDoItem).NotEmpty();
        RuleFor(x => x.Quantidade).GreaterThan(0);
    }
}