using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }

        // Relacionamento com o Cliente
        public Cliente Cliente { get; set; }

        // Relacionamento com os Itens de Venda
        public List<ItemVenda> ItensVenda { get; set; }

        [NotMapped]
        public double? Total {  get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public Status Status { get; set; }
    }
}
