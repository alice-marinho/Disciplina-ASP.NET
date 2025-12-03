using Model;
using System.ComponentModel.DataAnnotations;

namespace PROVA02.Models
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

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; } = true;

    

    }
}
