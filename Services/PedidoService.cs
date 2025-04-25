using LojaPedidosApi.Domain.Entities;
using LojaPedidosApi.Domain.Enums;
using LojaPedidosApi.Infrastructure.Data;

namespace LojaPedidosApi.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task<Pedido?> GetPedidoByIdAsync(Guid id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }

        public async Task<Pedido> AddPedidoAsync(Pedido pedido)
        {
            pedido.Id = Guid.NewGuid();
            pedido.DataCriacao = DateTime.Now;
            pedido.Status = StatusPedido.Aberto;
            
            await _pedidoRepository.AddAsync(pedido);
            return pedido;
        }

        public async Task UpdatePedidoAsync(Guid id, Pedido pedido)
        {
            var pedidoExistente = await _pedidoRepository.GetByIdAsync(id);
            if (pedidoExistente == null)
                throw new KeyNotFoundException("Pedido não encontrado");

            if (pedidoExistente.Status == StatusPedido.Fechado)
                throw new InvalidOperationException("Não é permitido alterar pedidos fechados");

            await _pedidoRepository.UpdateAsync(pedido);
        }

        public async Task FecharPedidoAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido não encontrado");

            if (pedido.Status == StatusPedido.Fechado)
                throw new InvalidOperationException("Pedido já está fechado");

            if (!pedido.Produtos.Any())
                throw new InvalidOperationException("Não é possível fechar um pedido sem produtos");

            pedido.Status = StatusPedido.Fechado;
            await _pedidoRepository.UpdateAsync(pedido);
        }

        public async Task DeletePedidoAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                throw new KeyNotFoundException("Pedido não encontrado");

            if (pedido.Status == StatusPedido.Fechado)
                throw new InvalidOperationException("Não é permitido excluir pedidos fechados");

            await _pedidoRepository.DeleteAsync(id);
        }
    }
}