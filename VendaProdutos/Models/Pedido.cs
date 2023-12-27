using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendaProdutos.Models
{ 
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe o seu nome completo")]
        [StringLength(50)]
        public string NomeComprador { get; set; }

        
        [Required(ErrorMessage = "Informe o seu apelido")]
        [StringLength(50)]
        public string ApelidoComprador { get; set; }


        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }


        [Display(Name = "CPF")]
        public string CPFComprador { get; set; }

        [Required(ErrorMessage = "Informe o seu nº de Whatsapp")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string WhatsappComprador { get; set; }


        [Required(ErrorMessage = "Informe o seu email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }



        [StringLength(50)]
        [Display(Name = "Nome Recebedor")]
        public string NomeRecebedor { get; set; }



        [StringLength(50)]
        [Display(Name = "Apelido Recebedor")]
        public string ApelidoRecebedor { get; set; }

        [StringLength(50)]
        [Display(Name = "Bairro Recebedor")]
        public string BairroRecebedor { get; set; }


        [StringLength(100)]
        [Display(Name = "Rua Recebedor")]
        public string RuaRecebedor { get; set; }

        [StringLength(200)]
        [Display(Name = "Complemento do Recebedor")]
        public string ComplementoRecebedor { get; set; }


        [StringLength(100)]
        [Display(Name = "Numero Da Casa")]
        public string NumeroCasaRecebedor { get; set; }

         

        [Required(ErrorMessage = "Informe o Whatsapp do Recebedor")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string WhatsappRecebedor { get; set; }









        [Display(Name = "Data da Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDeEntrega { get; set; }


        [Display(Name = "Hora da Entrega")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraDeEntrega { get; set; }












        [StringLength(300)]
        [Display(Name = "Observacoes do pedido")]
        public string Observacoes { get; set; }

        [StringLength(450)]
        [Display(Name = "Complemento do Recebedor")]
        public string Cartinha { get; set; }



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

        [Display(Name = "Pedido Eentregue")]
        public bool EntregaPedido { get; set; }


        public List<PedidoDetalhe> PedidoItens { get; set; }

    }
}
