using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFacil.Api.Damain.Models
{
    public class Areceber : Titulo

    {
       [Required(ErrorMessage = "O campo Valor Recebido é obrigatório.")]
        public double ValorRecebido { get; set; }

        public DateTime? DataRecebimento { get; set; }
    }
}