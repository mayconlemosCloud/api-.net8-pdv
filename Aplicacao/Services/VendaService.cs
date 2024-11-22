using Aplicacao.DTO;
using Aplicacao.Interfaces;
using AutoMapper;
using Dominio.Entities;

namespace Aplicacao.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            var vendas = await _vendaRepository.GetAllAsync();
            return _mapper.Map<List<Venda>>(vendas);
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
           
            return await _vendaRepository.GetByIdAsync(id);
        }

        public async Task<VendaDTO> AddAsync(VendaDTO vendaDto)
        {
            var venda = _mapper.Map<Venda>(vendaDto);
            await _vendaRepository.AddAsync(venda);
            return _mapper.Map<VendaDTO>(venda);
        }

        public async Task UpdateAsync(VendaDTO vendaDto)
        {
            var venda = _mapper.Map<Venda>(vendaDto);
            await _vendaRepository.UpdateAsync(venda);
        }

        public async Task DeleteAsync(int id)
        {
            await _vendaRepository.DeleteAsync(id);
        }
    }
}
