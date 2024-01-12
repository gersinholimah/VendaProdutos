using VendaProdutos.Models;

namespace VendaProdutos.ViewModel
{
    public class CarrinhoCompraViewModel
    {
       public IEnumerable<Produto> OpcoesExtra { get; set; }

        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }
    }
}
