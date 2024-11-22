using AutoMapper;
using Aplicacao.Interfaces;
using Dominio.Entities;
using Aplicacao.DTO;

namespace Aplicacao.Services
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IMapper _mapper;

        public ItemVendaService(IItemVendaRepository itemVendaRepository, IMapper mapper)
        {
            _itemVendaRepository = itemVendaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ItemVendaDTO itemVendaDTO)
        {
            var itemVenda = _mapper.Map<ItemVenda>(itemVendaDTO);
            await _itemVendaRepository.AddAsync(itemVenda);
        }

        public async Task DeleteAsync(int id)
        {
            await _itemVendaRepository.DeleteAsync(id);
        }

        public async Task<List<ItemVenda>> GetAllAsync()
        {
            var itensVenda = await _itemVendaRepository.GetAllAsync();
            return _mapper.Map<List<ItemVenda>>(itensVenda);
        }

        public async Task<ItemVenda> GetByIdAsync(int id)
        {
            var itemVenda = await _itemVendaRepository.GetByIdAsync(id);
            return _mapper.Map<ItemVenda>(itemVenda);
        }

        public async Task UpdateAsync(ItemVendaDTO itemVendaDTO)
        {
            var itemVenda = _mapper.Map<ItemVenda>(itemVendaDTO);
            await _itemVendaRepository.UpdateAsync(itemVenda);
        }
    }
}
