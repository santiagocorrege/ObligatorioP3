using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Usuario
{
    public class UsuarioLoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
