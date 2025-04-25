using Microsoft.AspNetCore.Mvc;
using LojaPedidosApi.Domain.Entities;
using LojaPedidosApi.Services;

namespace LojaPedidosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _pedidoService.GetPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(Guid id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(Pedido pedido)
        {
            var novoPedido = await _pedidoService.AddPedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = novoPedido.Id }, novoPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(Guid id, Pedido pedido)
        {
            await _pedidoService.UpdatePedidoAsync(id, pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(Guid id)
        {
            await _pedidoService.DeletePedidoAsync(id);
            return NoContent();
        }
    }
}
