using Dominio.Entities;
using System.Text.Json.Serialization;

namespace Aplicacao.DTO
{
    public class ItemVendaDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double? Preco { get; set; }   
        public string? Nome {  get; set; }

    }
}