using Microsoft.EntityFrameworkCore;
using LojaPedidosApi.Domain.Entities;

namespace LojaPedidosApi.Infrastructure.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.Include(p => p.Produtos).ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IPedidoRepository
    {
    }
}