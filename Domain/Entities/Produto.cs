namespace LojaPedidosApi.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}