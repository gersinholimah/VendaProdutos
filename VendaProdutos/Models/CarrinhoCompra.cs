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

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
    }
}
