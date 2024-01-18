using ECommerce.Application.UseCases.Vitrine;

namespace ECommerce.Infrastructure.Repositories.Vitrine;

internal class VitrineReadOnlyRepository : IVitrineReadOnlyRepository
{
    public Task<IReadOnlyCollection<Produto>> ListarMaisVendidos(CancellationToken cancellationToken = default)
    {
        var produtos = new List<Produto>
        {
            new Produto(Guid.NewGuid(), "Produto 1", 10.00m),
            new Produto(Guid.NewGuid(), "Produto 2", 20.00m),
            new Produto(Guid.NewGuid(), "Produto 3", 30.00m),
            new Produto(Guid.NewGuid(), "Produto 4", 40.00m),
        };
        
        return Task.FromResult<IReadOnlyCollection<Produto>>(produtos);
    }
}