using Aplicacao.DTO;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> AddAsync(ClienteDTO clienteDTO);
        Task UpdateAsync(ClienteDTO clienteDTO);
        Task DeleteAsync(int id);
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<List<ClienteDTO>> GetAllAsync();
    }
}
