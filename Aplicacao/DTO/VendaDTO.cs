using Dominio.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.DTO
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public required List<ItemVendaDTO> ItensVenda { get; set; }

        [NotMapped]
        public double? Total { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public Status Status => Status.Preparando;
    }
}
