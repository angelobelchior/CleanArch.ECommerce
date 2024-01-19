using ECommerce.Application.UseCases.Carrinho.AdicionarItemAoPedido;
using ECommerce.Domain;
using ECommerce.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AspNetResult = Microsoft.AspNetCore.Http.IResult;

namespace ECommerce.WebAPI.Endpoints;

public static class Carrinho
{
    public static WebApplication UseCarrinhoEndpoints(this WebApplication app)
    {
        app.MapPost("v1/carrinho/{idPedido}", (
                        IMediator mediator,
                        Guid idPedido,
                        [FromBody] CarrinhoModel carrinho,
                        CancellationToken cancellationToken)
                => SenderResult.Send<AdicionarItemAoPedidoCommand, AdicionarItemAoPedidoResult>(
                    mediator, 
                    new AdicionarItemAoPedidoCommand(idPedido, carrinho.IdItem, carrinho.Quantidade), 
                    cancellationToken)
                )
            .WithName("AdicionarItemAoPedidoV1")
            .WithOpenApi();

        return app;
    }
}

public static class SenderResult
{
    public static async Task<AspNetResult> Send<TRequest, TResponse>(
        IMediator mediator,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<Result<TResponse>>
    {
        try
        {
            var result = await mediator.Send(request, cancellationToken);
            switch (result.Status)
            {
                case ResultStatus.HasError:
                    return Results.Problem();
                case ResultStatus.HasValidation:
                    return Results.BadRequest(result.Validations);
                default:
                    return Results.Ok(result.Data);
            }
        }
        catch (ResultException e)
        {
            return Results.BadRequest(e.Result.Validations);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }
}