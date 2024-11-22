using Aplicacao.Interfaces;
using Dominio.Entities;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly AppDbContext _context;

        public ItemVendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ItemVenda itemVenda)
        {
            await _context.ItensVenda.AddAsync(itemVenda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemVenda = await _context.ItensVenda.FindAsync(id);
            if (itemVenda != null)
            {
                _context.ItensVenda.Remove(itemVenda);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ItemVenda>> GetAllAsync()
        {
            return await _context.ItensVenda.Include(i => i.Produto).Include(i => i.Venda).ToListAsync();
        }

        public async Task<ItemVenda> GetByIdAsync(int id)
        {
            return await _context.ItensVenda.Include(i => i.Produto).Include(i => i.Venda).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(ItemVenda itemVenda)
        {
            _context.ItensVenda.Update(itemVenda);
            await _context.SaveChangesAsync();
        }
    }
}
