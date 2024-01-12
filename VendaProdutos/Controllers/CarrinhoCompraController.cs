using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, 
            CarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
             
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;
            IEnumerable<Produto> listaOpcoesExtra = _produtoRepository.Produtos.Where(c => c.OpcaoExtra).ToList();

            var carrinhCompraVM = new CarrinhoCompraViewModel 
            {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            OpcoesExtra = listaOpcoesExtra

            };
            return View(carrinhCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int produtoId) {

            var produtoSelecionado = _produtoRepository.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);
         if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
            }
         return RedirectToAction("Index");
        }






        public IActionResult AdicionarItemNoCarrinhoCompraAjax(int produtoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
                return Json(new { success = true, mensagem = "Produto adicionado ao carrinho com sucesso!" });
            }

            return Json(new { success = false, mensagem = "Falha ao adicionar o produto ao carrinho." });
        }









        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
        {

            var produtoSelecionado = _produtoRepository.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
