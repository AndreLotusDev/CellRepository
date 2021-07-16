using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationModels
{
    public class UserLoginDto
    {
        [Required, MinLength(10, ErrorMessage = "Sua senha deve conter no mínimo 10 carácteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string UserName { get; set; }

        [   Required(ErrorMessage = "O email é obrigatório"), 
            EmailAddress(ErrorMessage = "Não é um email válido")]
        public string Email { get; set; }
        public string RealName { get; set; }
    }
}
