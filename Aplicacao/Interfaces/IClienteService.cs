using Aplicacao.DTO;
using Dominio.Entities;

namespace Aplicacao.Interfaces
{
    public interface IClienteService
    {
        Task<IResult<Cliente>> AddAsync(ClienteDTO clienteDTO);
        Task UpdateAsync(ClienteDTO clienteDTO);
        Task DeleteAsync(int id);
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<List<ClienteDTO>> GetAllAsync();
    }
}
