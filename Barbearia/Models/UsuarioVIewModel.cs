using Barbearia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.Models
{
    public class UsuarioVIewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Tipo { get; set; }
    }
}
