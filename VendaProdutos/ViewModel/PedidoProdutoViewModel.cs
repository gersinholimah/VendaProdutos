using VendaProdutos.Areas.Admin.Controllers;
using VendaProdutos.Models;

namespace VendaProdutos.ViewModel
{
    public class PedidoProdutoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
        //Criei o tipo ChavePix no lugar errado, era pra ser na viewmodel ou no model e eu crieri no proprio repositorio de controller
        public ChavePix ChavePix { get; set; }

    }
}
