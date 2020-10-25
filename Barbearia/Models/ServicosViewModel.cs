using Barbearia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.Models
{
    public class ServicosViewModel : PadraoViewModel
    {
        public string Tipo { get; set; }
        public DateTime Tempo { get; set; }
        public double Valor { get; set; }
    }
}
