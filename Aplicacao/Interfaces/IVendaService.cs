using Aplicacao.DTO;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IVendaService
    {
        Task<List<Venda>> GetAllAsync();
        Task<Venda> GetByIdAsync(int id);
        Task<VendaDTO> AddAsync(VendaDTO vendaDto);
        Task UpdateAsync(VendaDTO vendaDto);
        Task DeleteAsync(int id);
    }
}
