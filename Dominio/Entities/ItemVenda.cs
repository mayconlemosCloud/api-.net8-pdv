using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        [NotMapped]
        public string? Nome { get; set; }

        [NotMapped]
        public double? Preco { get; set; }

        // Relacionamento com a Venda e Produto
        public Venda? Venda { get; set; }
        public Produto? Produto { get; set; }
    }
}
