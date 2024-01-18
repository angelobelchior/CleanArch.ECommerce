using ECommerce.Application.UseCases.Vitrine.ObterProdutosMaisVendidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Endpoints;

public static class Vitrine
{
    public static WebApplication UseVitrineEndpoints(this WebApplication app)
    {
        app.MapGet("v1/vitrine", (
                    IMediator mediator, 
                    CancellationToken cancellationToken) 
                => mediator.Send(new ObterProdutosMaisVendidosQuery(string.Empty), cancellationToken))
            .WithName("ObterProdutosMaisVendidosQueryV1")
            .WithOpenApi();
        
        app.MapGet("v2/vitrine", (
                    IMediator mediator, 
                    [FromQuery] string ordernacao,
                    CancellationToken cancellationToken) 
                => mediator.Send(new ObterProdutosMaisVendidosQuery(ordernacao), cancellationToken))
            .WithName("ObterProdutosMaisVendidosQueryV2")
            .WithOpenApi();

        return app;
    }
}