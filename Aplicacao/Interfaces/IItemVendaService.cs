using Aplicacao.DTO;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IItemVendaService
    {
        Task AddAsync(ItemVendaDTO itemVendaDTO);
        Task UpdateAsync(ItemVendaDTO itemVendaDTO);
        Task DeleteAsync(int id);
        Task<ItemVenda> GetByIdAsync(int id);
        Task<List<ItemVenda>> GetAllAsync();
    }
}
