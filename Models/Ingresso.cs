using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Ingresso
    {
        public int _id { get; set; }
        public bool _meia { get; set; }
        public int _sessaoId { get; set; }
        public int _vendaId { get; set; }
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