using ECommerce.Application.UseCases.Vitrine.ListarProdutosComMelhoresAvaliacoes;
using ECommerce.Application.UseCases.Vitrine.ListarProdutosMaisVendidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Endpoints;

public static class Vitrine
{
    public static WebApplication UseVitrineEndpoints(this WebApplication app)
    {
        app.MapGet("v1/vitrine/mais-vendidos", (
                    IMediator mediator, 
                    CancellationToken cancellationToken) 
                => mediator.Send(new ListarProdutosMaisVendidosQuery(string.Empty), cancellationToken))
            .WithName("ObterProdutosMaisVendidosV1")
            .WithOpenApi();
        
        app.MapGet("v2/vitrine/mais-vendidos", (
                    IMediator mediator, 
                    [FromQuery] string ordernacao,
                    CancellationToken cancellationToken) 
                => mediator.Send(new ListarProdutosMaisVendidosQuery(ordernacao), cancellationToken))
            .WithName("ObterProdutosMaisVendidosV2")
            .WithOpenApi();
        
        app.MapGet("v2/vitrine/melhores-avaliados", (
                    IMediator mediator, 
                    [FromQuery] string ordernacao,
                    CancellationToken cancellationToken) 
                => mediator.Send(new ListarProdutosComMelhoresAvaliacoesQuery(), cancellationToken))
            .WithName("ListarProdutosComMelhoresAvaliacoes")
            .WithOpenApi();

        return app;
    }
}