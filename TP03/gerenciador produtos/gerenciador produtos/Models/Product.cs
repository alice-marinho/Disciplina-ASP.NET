using System.ComponentModel.DataAnnotations;

namespace gerenciador_produtos.Models
{
  
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Preço deve ser um valor não negativo")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser um número inteiro não negativo")]
        public int Qtde_estoque { get; set; }
    }
}
