using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Apagar
{
    public class ApagarRequestContract
    {
        public long IdNaturezaDeLancamento { get; set;}
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}