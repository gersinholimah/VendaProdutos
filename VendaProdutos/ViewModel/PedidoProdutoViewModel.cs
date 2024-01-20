﻿using VendaProdutos.Models;

namespace VendaProdutos.ViewModel
{
    public class PedidoProdutoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

        

    }
}
