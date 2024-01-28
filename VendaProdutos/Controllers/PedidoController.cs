using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;
        private readonly IProdutoRepository _produtoRepository;
        private readonly AppDbContext _context;


        public PedidoController(IPedidoRepository pedidoRepository, 
            CarrinhoCompra carrinhoCompra,
            IProdutoRepository produtoRepository, AppDbContext context)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
            _produtoRepository = produtoRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();

            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
             ViewBag.CarrinhoItens = items;






            var PedidosFeitos = _context.Pedidos.ToList();

            Dictionary<string, List<string>> entregasPorData = new Dictionary<string, List<string>>();

            foreach (var pedido in PedidosFeitos)
            {
                if (pedido.PagamentoParcial > 0 || pedido.PagamentoNaEntrega) { 
                string dataEntrega = pedido.DataDeEntrega;
                string horaEntrega = pedido.HoraDeEntrega;

                // Verifica se a chave (dataEntrega) já existe no dicionário
                if (entregasPorData.ContainsKey(dataEntrega))
                {
                    // Adiciona a horaEntrega ao array existente
                    entregasPorData[dataEntrega].Add(horaEntrega);
                }
                else
                {
                    // Cria uma nova entrada no dicionário com a chave e um novo array contendo a horaEntrega
                    entregasPorData[dataEntrega] = new List<string> { horaEntrega };
                }
                }
            }

            ViewBag.EntregasPorData = entregasPorData;
            ViewBag.limiteDePedidoPorHora = 9;
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;



            return View();

        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;
            //obtem os itens do carrinho de compra do cliente
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

             ViewBag.ProdutosCheckout = _produtoRepository.Produtos;
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            //verifica se existem itens de pedido
            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, adicione um produto...");
            }

            //calcula o total de itens e o totall do pedido
            foreach(var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Produto.Preco * item.Quantidade);
            }

            //atribui os valores obtidos ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.TotalPedido = precoTotalPedido;

                //valida os dados do pedido
                if (ModelState.IsValid)
            {
                //cria o pedido e os detalhesdo pedido.
                _pedidoRepository.CriarPedido(pedido);

                //define mensagens ao cliente
                    ViewBag.CheckoutCompletoMensagem = "Voce está a 1 passo de concluir o seu pedido :)";
                    ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpar o carrinho do cliente

                _carrinhoCompra.LimparCarrinho();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);
         }
    }
}
