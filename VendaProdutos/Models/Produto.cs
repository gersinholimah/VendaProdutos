using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaProdutos.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Informe o Sku do Produto corretamente")]
        [Display(Name = "Sku do Produto")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O {0} deve ter no máximo {1} e no mínimo {2} caracteres")]

        public string Sku { get; set; }

        [Required(ErrorMessage = "Informe a Altura do Produto corretamente")]
        [Display(Name = "Altura do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]

        public decimal Altura { get; set; }

        [Required(ErrorMessage = "Informe a Largura do Produto corretamente")]
        [Display(Name = "Largura do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal Largura { get; set; }

        [Required(ErrorMessage = "Informe a Profundidade do Produto corretamente")]
        [Display(Name = "Profundidade do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal Profundidade { get; set; }

        [Required(ErrorMessage = "Informe o Comprimento do Produto corretamente")]
        [Display(Name = "Comprimento do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal Comprimento { get; set; }

        [Required(ErrorMessage = "Informe o Peso do Produto corretamente")]
        [Display(Name = "Peso do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "Informe as Imagens do Produto corretamente")]
        [Display(Name = "Imagens do Produto")]
        [StringLength(100, MinimumLength = 25, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string GaleriaImagemURL { get; set; }

        [Display(Name = "2ª Imagen do carousel do Produto")]
        [StringLength(100, MinimumLength = 25, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string Imagem2CarolselURL { get; set; }

        [Display(Name = "3ª Imagen do carousel do Produto")]
        [StringLength(100, MinimumLength = 25, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string Imagem3CarolselURL { get; set; }

        [Display(Name = "4ª Imagen do carousel do Produto")]
        [StringLength(100, MinimumLength = 25, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string Imagem4CarolselURL { get; set; }

        [StringLength(100, MinimumLength = 25, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        [Required(ErrorMessage = " Para acessibilidade descreva a imagem Corretamente")]
        [Display(Name = "Descrição da imagem do produto")]
        public string DescricaoImgTagAlt { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Produto corretamente")]
        [Display(Name = "Nome do Produto")]
        [StringLength(70, MinimumLength = 4, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Descrição Curta do Produto corretamente")]
        [Display(Name = "Descrição Curta do Produto")]
        [StringLength(300, MinimumLength = 200, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Informe a Descrição Detalhada do Produto corretamente")]
        [Display(Name = "Descrição Detalhada do Produto")]
        [StringLength(100000, MinimumLength = 500, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [StringLength(100000, MinimumLength = 500, ErrorMessage = "O tamanho minimo é 500 caracteres e o máximo 10000")]
        [Required(ErrorMessage = "Informe o post inferior categoria Corretamente")]
        [Display(Name = "post inferior da categoria")]
        public string PostInferior { get; set; }

        [Required(ErrorMessage = "Informe o Preço Promocional do Produto corretamente")]
        [Display(Name = "Preço Promocional do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal PrecoPromocional { get; set; }

        [Required(ErrorMessage = "Informe o Preço do Produto corretamente")]
        [Display(Name = "Preço do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "A {0} deve estar entre 1 e 9999.99")]
        public decimal Preco { get; set; }


        public int Parcela { get; set; }

        [Required(ErrorMessage = "Informe a Meta Descrição do Produto corretamente")]
        [Display(Name = "Meta tag de Descrição do Produto")]
        [StringLength(160, MinimumLength = 120, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string MetaDescricao { get; set; }

        [Required(ErrorMessage = "Informe a Meta tag de Imagem do Produto corretamente")]
        [Display(Name = "Meta tag de Imagem do Produto")]
        [StringLength(100, MinimumLength = 30, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string MetaImage { get; set; }

        [Required(ErrorMessage = "Informe o Tíutlo do Produto corretamente")]
        [Display(Name = "Meta tag de Tíutlo do Produto")]
        [StringLength(80, MinimumLength = 50, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Informe a Url Amigavel do Produto corretamente")]
        [Display(Name = "Url Amigavel do Produto")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string UrlAmigavel { get; set; }

        [Required(ErrorMessage = "Informe a Url da principal imagem do Produto corretamente")]
        [Display(Name = "Url da principal imagem do Produto")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "Informe a Url da miniatura da principal imagem do Produto corretamente")]
        [Display(Name = "Url da miniatura da principal imagem do Produto")]
        [StringLength(100, MinimumLength = 50, ErrorMessage = "A {0} deve ter no máximo {1} e no mínimo {2} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Produto Em Alta")]
        public bool IsProdutoEmAlta { get; set; }

        [Display(Name = "Produto Esgotado")]
        public bool Esgotado { get; set; }

        [Display(Name = "Taxa De Entrega")]
        public int TaxaDeEntrega { get; set; }

        [Display(Name = "Sob Encomenda")]
        public bool SobEncomenda { get; set; }

        [Display(Name = "Opção Extra")]
        public bool OpcaoExtra { get; set; }

        [Display(Name = "Não Vender Individual")]
        public bool NaoVenderIndividualmente { get; set; }

        public int QuantidadeDeItem { get; set; }




        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}