using ECommerce.Domain.Carrinho.TiposDeDesconto;

namespace ECommerce.Domain.Carrinho;

public sealed record Pedido(
    Guid Id, 
    DateTime DataHora, 
    Cliente Cliente)
{
    public IReadOnlyCollection<ItemPedido> Itens => _itens;
    public decimal ValorDoFrete { get; private set; } = 0;
    public decimal ValorDoDesconto { get; private set; } = 0;
    public decimal ValorTotal => CalcularValorTotal();
    
    private readonly List<ItemPedido> _itens = new();
    
    public static Pedido Criar(
        DateTime dataHora, 
        Cliente cliente)
    {
        return new Pedido(Guid.NewGuid(), dataHora, cliente);
    }
    
    public static Pedido CriarComItens(
        DateTime dataHora, 
        Cliente cliente, 
        IEnumerable<ItemPedido> itens)
    {
        var pedido = new Pedido(Guid.NewGuid(), dataHora, cliente);
        pedido.AdicionarItens(itens.ToArray());
        return pedido;
    }
    
    public Pedido AdicionarItens(params ItemPedido[] items)
    {
        foreach (var item in items)
        {
            var itemExistente = _itens.FirstOrDefault(x => x.Id == item.Id);
            if (itemExistente is null)
            {
                _itens.Add(item);
                continue;   
            }
            
            var itemComQuantidadeAtualizada = itemExistente with { Quantidade = itemExistente.Quantidade + item.Quantidade };
            _itens.Add(itemComQuantidadeAtualizada);
            _itens.Remove(itemExistente);
        }
        return this;
    }

    public Pedido RemoverItens(params ItemPedido[] items)
    {
        foreach (var item in items)
        {
            var itemExistente = _itens.FirstOrDefault(x => x.Id == item.Id);
            if(itemExistente is not null)
                _itens.Remove(itemExistente);
        }
        return this;
    }
    
    public Pedido AplicarValorDoFrete(decimal valorDoFrete)
    {
        ValorDoFrete = valorDoFrete;
        return this;
    }

    public Pedido AplicarDesconto(IAplicadorDeDesconto aplicadorDeDesconto)
    {
        ValorDoDesconto = aplicadorDeDesconto.AplicarDesconto(this, ValorDoDesconto);
        return this;
    }

    // Para efeitos de demonstração
    internal decimal CalcularValorTotal()
    {
        var valorTotal = _itens.Sum(x => x.Quantidade * x.Preco);
        valorTotal += ValorDoFrete;
        valorTotal -= ValorDoDesconto;
        return valorTotal;
    }
}


public sealed record Cliente(Guid Id, Guid IdEnderecoDeEntrega);

public sealed record ItemPedido(Guid Id, int Quantidade, decimal Preco);
