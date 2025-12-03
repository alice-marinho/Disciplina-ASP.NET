using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Model
{
    [Table("Usuarios")]
    public class Usuario : IdentityUser<int>
    {
        public string Nome { get; set; }
        public bool Status {  get; set; }
    }

    [XmlType("Usuario")]
    public class UsuarioApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}
