using LojaPedidosApi.Domain.Enums;

namespace LojaPedidosApi.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusPedido Status { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal ValorTotal => Produtos?.Sum(p => p.Preco) ?? 0;

        public Pedido()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Status = StatusPedido.Aberto;
            Produtos = new List<Produto>();
        }

        internal void Fechar()
        {
            throw new NotImplementedException();
        }
    }
}