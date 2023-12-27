using VendaProdutos.Models;

namespace VendaProdutos.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
