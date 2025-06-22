using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class VendaRequest
    {
        public Venda _venda { get; set; }
        public List<Assento> _assentos { get; set; }

        [Required (ErrorMessage = ("A Sessão é obrigatório!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("A Sessão é obrigatório!"))]
        public int _sessaoId { get; set; }
        public int _quantidadeMeiaEntrada { get; set; }
    }
}