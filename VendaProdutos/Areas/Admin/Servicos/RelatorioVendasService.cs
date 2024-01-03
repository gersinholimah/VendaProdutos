using VendaProdutos.Context;
using VendaProdutos.Models;
using Microsoft.EntityFrameworkCore;
 

namespace VendaProdutos.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext context;
        public RelatorioVendasService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate, bool? pagamentoPedido)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            if (pagamentoPedido.HasValue)
            {
                resultado = resultado.Where(x => x.PagamentoPedido == pagamentoPedido.Value);
            }

            return await resultado
                         .Include(l => l.PedidoItens)
                         .ThenInclude(l => l.Produto)
                         .OrderByDescending(x => x.PedidoEnviado)
                         .ToListAsync();
        }
    }
}
