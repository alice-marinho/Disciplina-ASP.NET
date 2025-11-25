using Model;
using System.ComponentModel.DataAnnotations;

namespace TP04.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço Unitário")]
        [DataType(DataType.Currency)] 
        public decimal Preco { get; set; }

        [Display(Name = "Seção do Mercado")]
        [Required(ErrorMessage = "Escolha uma categoria")]
        public CategoriaProduto Categoria { get; set; }

        [Display(Name = "Descrição Detalhada")]
        public string Descricao { get; set; }
    }
}
