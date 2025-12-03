using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PROVA02.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
