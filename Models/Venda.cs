using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_cinema.Models
{
    public class Venda
    {
        public int? _id { get; set; }
        [Required (ErrorMessage = ("O Sub-Total é obrigatório!"))]
        [Range(0.1, double.MaxValue, ErrorMessage = ("O Sub-Total deve ser maior do que zero!"))]
        public double _subTotal { get; set; }
        [Required (ErrorMessage = ("A data da venda é obrigatória!"))]
        public DateTime _data { get; set; }
        public double _desconto { get; set; }

        [Required (ErrorMessage = ("O Total é obrigatório!"))]
        [Range(0.1, double.MaxValue, ErrorMessage = ("O Total deve ser maior do que zero!"))]
        public double _total { get; set; }
        public int _clienteId { get; set; }
        [Required (ErrorMessage = ("O Caixa é obrigatório!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("O Caixa é obrigatório!"))]
        public int _caixaId { get; set; }
        [Required (ErrorMessage = ("A Forma de Pagamento é obrigatório!"))]
        [Range(1, int.MaxValue, ErrorMessage = ("A Forma de Pagamento é obrigatório!"))]
        public int _formaPagamentoId { get; set; }
        public Cliente? _cliente { get; set; }
        public Caixa? _caixa { get; set;}
        public FormaPagamento? _formaPagamento { get; set;}


        public Venda()
        {

        }

        public Venda(int id, double subTotal, DateTime data, double desconto, double total, int idCliente, int idCaixa, int idFormaPagamento, Cliente cliente = null, Caixa caixa = null, FormaPagamento formaPagamento = null){
            _id = id;
            _subTotal = subTotal;
            _data = data;
            _desconto = desconto;
            _total = total;
            _clienteId = idCliente;
            _caixaId = idCaixa;
            _formaPagamentoId = idFormaPagamento;
            _cliente = cliente;
            _caixa = caixa;
            _formaPagamento = formaPagamento;
        }
    }
}