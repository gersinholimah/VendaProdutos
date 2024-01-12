using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaProdutos.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "O tamanho máximo é 50 e o minimo é 4 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria Corretamente")]
        [Display(Name = "Nome da categoria")]
        public string CategoriaNome { get; set; }

        [StringLength(38, MinimumLength = 20, ErrorMessage = "O tamanho máximo é 38 e o minimo é 20  caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria Corretamente")]
        [Display(Name = "Descrição da categoria")]
        public string Descricao { get; set; }

        [StringLength(100, MinimumLength = 4, ErrorMessage = "O tamanho máximo é 100 e o minimo é 4 caracteres")]
        [Required(ErrorMessage = "Informe a url da Imagem de destaque da categoria Corretamente")]
        [Display(Name = "Url da Imagem da categoria")]
        public string ImagemDestaque { get; set; }

        [StringLength(100, MinimumLength = 25, ErrorMessage = "O tamanho máximo é 100 e o minimo é 25 caracteres")]
        [Required(ErrorMessage = " Para acessibilidade descreva a imagem Corretamente")]
        [Display(Name = "Descrição da imagem da categoria")]
        public string DescricaoTagAlt { get; set; }

        [StringLength(100000, MinimumLength = 500, ErrorMessage = "O tamanho minimo é 500 caracteres e o máximo 10000")]
        [Required(ErrorMessage = "Informe o post superior categoria Corretamente")]
        [Display(Name = "post superior da categoria")]
        public string PostSuperior { get; set; }

        [StringLength(100000, MinimumLength = 500, ErrorMessage = "O tamanho minimo é 500 caracteres e o máximo 10000")]
        [Required(ErrorMessage = "Informe o post inferior categoria Corretamente")]
        [Display(Name = "post inferior da categoria")]
        public string PostInferior { get; set; }


        [StringLength(160, MinimumLength = 120, ErrorMessage = "O tamanho minimo é 120 e o máximo é 160 caracteres")]
        [Required(ErrorMessage = "Informe a descricao da tag de SEO da categoria Corretamente")]
        [Display(Name = "tag de descricao da categoria")]
        public string MetaDescricao { get; set; }

        [StringLength(100, MinimumLength = 30, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe a url da Imagem para a tag de SEO da categoria Corretamente")]
        [Display(Name = "Url da tag de Imagem da categoria")]
        public string MetaImage { get; set; }

        [StringLength(80, MinimumLength = 50, ErrorMessage = "O tamanho minimo é 50 e o máximo 80 caracteres")]
        [Required(ErrorMessage = "Informe o texto para o titulo da tag description de SEO da categoria Corretamente")]
        [Display(Name = "texto para o titulo da categoria")]
        public string MetaTitle { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe uma url amigavel para a categoria Corretamente")]
        public string UrlAmigavel { get; set; }
        

        [StringLength(160, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o Nome Curto para a categoria Corretamente")]
        public string NomeCurto { get; set; }

        [Display(Name = "Esconder Categoria")]
        public bool EsconderCategoria { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}