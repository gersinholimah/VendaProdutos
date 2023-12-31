using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendaProdutos.Models
{ 
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe o nome de quem está enviando")]
        [StringLength(50)]
        public string NomeComprador { get; set; }
          

        [Required(ErrorMessage = "Informe o seu Whatsapp")]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string WhatsappComprador { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Recebedor")]
        [StringLength(50)]
        [Display(Name = "Nome Recebedor")]
        public string NomeRecebedor { get; set; }


        [Required(ErrorMessage = "Informe o Bairro da entrega")]
        [StringLength(50)]
        [Display(Name = "Bairro Recebedor")]
        public string BairroRecebedor { get; set; }


        [Required(ErrorMessage = "Informe a Rua  da entrega")]
        [StringLength(100)]
        [Display(Name = "Rua Recebedor")]
        public string RuaRecebedor { get; set; }

        [StringLength(200)]
        [Display(Name = "Complemento do endereco")]
        public string ComplementoRecebedor { get; set; }


        [StringLength(100)]
        [Display(Name = "Numero Da Casa")]
        public string NumeroCasaRecebedor { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome da Empresa")]
        public string NomeDaEmpresa { get; set; }

        [StringLength(100)]
        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [StringLength(100)]
        [Display(Name = "Ponto de Referencia")]
        public string PontoDeReferencia { get; set; }

        [Required(ErrorMessage = "Informe o Whatsapp do Recebedor")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string WhatsappRecebedor { get; set; }








        [Required(ErrorMessage = "Informe a Data da Entrega")]
        [StringLength(30)]

        [Display(Name = "Data da Entrega")]
         public string DataDeEntrega { get; set; }

        [Required(ErrorMessage = "Informe a Hora da Entrega")]
        [StringLength(30)]

        [Display(Name = "Hora da Entrega")]
          public string HoraDeEntrega { get; set; }









        [StringLength(30)]
        [Display(Name = "Telefone do comprador")]
        public string TelefoneCompradorDiferenteDoCadastro { get; set; }



        [StringLength(300)]
        [Display(Name = "Observacoes do pedido")]
        public string Observacoes { get; set; }

        [StringLength(450)]
        [Display(Name = "Complemento do Recebedor")]
        public string Cartinha { get; set; }


        [StringLength(450)]
        [Display(Name = "Comprovante de Pagamento")]
        public string ComprovanteDePagamento { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal TotalPedido { get; set; }



        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedido { get; set; }


        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }



        [Display(Name = "Pagamento Pedido")]
        public bool PagamentoPedido { get; set; }

        [Display(Name = "Pagamento na Entrega")]
        public bool PagamentoNaEntrega { get; set; }

        [Display(Name = "Pedido Eentregue")]
        public bool EntregaPedido { get; set; }


        public List<PedidoDetalhe> PedidoItens { get; set; }

    }
}
