using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id); 
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> AddAsync(Cliente cliente); 
        Task UpdateAsync(Cliente cliente); 
        Task DeleteAsync(int id); 
    }
}
