using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Model
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public int IdUsuarioUpdate {  get; set; }

    }

    [XmlType("Produto")]
    public class ProdutoApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public int IdUsuarioUpdate { get; set; }
    }
}
