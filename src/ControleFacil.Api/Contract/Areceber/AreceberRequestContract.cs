using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Contract.Areceber
{
    public class AreceberRequestContract
    {
        public long IdNaturezaDeLancamento { get; set;}
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public double ValorOriginal { get; set; }
        public double ValorRecebido { get; set; }
        public DateTime? DataReferencia { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}