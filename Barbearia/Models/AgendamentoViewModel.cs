using Barbearia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barbearia.Models
{
    public sealed class AgendamentoViewModel : PadraoViewModel
    {
        public int IdCliente { get; set; }
        public int IdUnidade { get; set; }
        public int IdColaborador { get; set; }
        public int IdServico { get; set; }
        public DateTime Data { get; set; }
    }
}
