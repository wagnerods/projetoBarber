using Barbearia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.Models
{
    public sealed class ServicosColaboradorViewModel : PadraoViewModel
    {
        public int IdColaborador { get; set; }
        public int IdServico { get; set; }
    }
}
