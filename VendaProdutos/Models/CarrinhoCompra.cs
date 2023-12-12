using VendaProdutos.Context;

namespace VendaProdutos.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sesssão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //obtem um servço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();
            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);
            //retorna o carrinho com o contexto e o Id atribuido ou obitido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        public void AdicionarAoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s=> s.Produto.ProdutoId == produto.ProdutoId &&
                s.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            // dentro do escopo os codigos onde tem quantidadeLocal só é necessário por RemoveDoCarrinho ser int se for void posso remover
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s=> s.Produto.ProdutoId == produto.ProdutoId && 
                s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
              if ( carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
              else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
                    }
            _context.SaveChanges();
          return quantidadeLocal;
        }
    }
}
