using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IItemVendaRepository
    {
        Task<ItemVenda> GetByIdAsync(int id);
        Task<List<ItemVenda>> GetAllAsync();
        Task AddAsync(ItemVenda itemVenda);
        Task UpdateAsync(ItemVenda itemVenda);
        Task DeleteAsync(int id);
    }
}
