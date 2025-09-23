/***
 * @author: Alice Marinho 
 ***/

using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistweb_container_bl.Models
{
    [Table("bl")]
    public class BL
    {
        [Column("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O número do BL é obrigatório")]
        public string numero { get; set; }

        public string consignee { get; set; }
        public string navio { get; set; }

        public ICollection<Container> Containers { get; set; } = new List<Container>();
    }

    [Table("container")]
    public class Container
    {
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do container é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número deve ter exatamente 11 caracteres.")]
        [Column(TypeName = "char(11)")]
        public string numero { get; set; }
        public string tipo { get; set; }
        public string tamanho { get; set; }


        public int id_bl { get; set; }
        [ForeignKey("id_bl")]
        public BL? BL { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BL> BL { get; set; }
        public DbSet<Container> Containers { get; set; }
    }

}
