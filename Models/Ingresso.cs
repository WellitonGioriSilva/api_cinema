using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Ingresso
    {
        public int _id { get; set; }
        public bool _meia { get; set; }
        [Required (ErrorMessage = ("A Sessão é obrigatória!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("A Sessão é obrigatória"))]
        public int _sessaoId { get; set; }

        [Required (ErrorMessage = ("A Venda é obrigatória!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("A Venda é obrigatória"))]
        public int _vendaId { get; set; }

        [Required (ErrorMessage = ("O Assento é obrigatório!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("O Assento é obrigatório"))]
        public int _assentoId { get; set; }
        public Sessao? _sessao { get; set; }
        public Venda? _venda { get; set; }
        public Assento? _assento { get; set; }
        public Ingresso()
        {
           
        }
        public Ingresso(int id, bool meia, int sessaoId, int vendaId, int assentoId, Sessao sessao = null, Venda venda = null, Assento assento = null)
        {
            _id = id;
            _meia = meia;
            _sessaoId = sessaoId;
            _vendaId = vendaId;
            _assentoId = assentoId;
            _sessao = sessao;
            _venda = venda;
            _assento = assento;
        }
    }
}