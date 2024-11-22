using Aplicacao.DTO;

namespace Aplicacao.Interfaces
{
    public interface IProdutoService
    {
        Task AddAsync(ProdutoDTO produtoDto);
        Task UpdateAsync(ProdutoDTO produtoDto);
        Task DeleteAsync(int id);
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task<List<ProdutoDTO>> GetAllAsync();
    }
}
