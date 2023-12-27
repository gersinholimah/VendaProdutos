using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbcontext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbcontext,
            CarrinhoCompra carrinhoCompra)
        {
            _appDbcontext = appDbcontext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbcontext.Pedidos.Add(pedido);
            _appDbcontext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Produto.Preco
                };
                _appDbcontext.PedidosDetalhe.Add(pedidoDetail);
            }
            _appDbcontext.SaveChanges();
        }
    }
}
