using ECommerce.Application.UseCases.Vitrine;

namespace ECommerce.Infrastructure.Repositories.Vitrine;

internal class VitrineReadOnlyRepository : IVitrineReadOnlyRepository
{
    public Task<IReadOnlyCollection<Produto>> ListarProdutosMaisVendidos(CancellationToken cancellationToken = default)
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

    public Task<IReadOnlyCollection<Produto>> ListarProdutosComMelhoresAvaliacoes(CancellationToken cancellationToken = default)
    {
        var produtos = new List<Produto>
        {
            new Produto(Guid.NewGuid(), "Produto 5", 50.00m),
            new Produto(Guid.NewGuid(), "Produto 6", 60.00m),
            new Produto(Guid.NewGuid(), "Produto 7", 70.00m),
            new Produto(Guid.NewGuid(), "Produto 8", 80.00m),
            new Produto(Guid.NewGuid(), "Produto 9", 90.00m),
        };
        
        return Task.FromResult<IReadOnlyCollection<Produto>>(produtos);
    }
}