using Dominio.Entities;

namespace Aplicacao.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<List<Cliente>> GetAllAsync();
        Task<IResult<Cliente>> AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
