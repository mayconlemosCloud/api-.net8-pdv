using Aplicacao.DTO;
using Aplicacao.Interfaces;
using Dominio.Entities;
using Dominio.Enum;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            var query = _context.Vendas.
                 Select(venda => new Venda
                 {
                     Id = venda.Id,
                     DataVenda = venda.DataVenda,
                     ClienteId = venda.ClienteId,
                     FormaPagamento = (FormaPagamento)venda.FormaPagamento,
                     Status = (Status)venda.Status,

                     ItensVenda = venda.ItensVenda.Select(i => new ItemVenda
                     {
                         Id = i.Id,
                         ProdutoId = i.ProdutoId,
                         Quantidade = i.Quantidade,
                         Nome = i.Produto.Nome,
                         Preco = i.Produto.Preco * i.Quantidade
                     }).ToList(),

                  Total = venda.ItensVenda.Sum(i => i.Produto.Preco * i.Quantidade)


                 });

        Debug.WriteLine(query.ToQueryString());

        return await query.ToListAsync();

        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _context.Vendas.Where(venda => venda.Id == id).Select(venda => new Venda
            {
                Id = venda.Id,
                DataVenda = venda.DataVenda,
                ClienteId = venda.ClienteId,
                ItensVenda = venda.ItensVenda
                .Where(i => i.Produto != null)
                .Select(
                          i => new ItemVenda
                          {
                              Id = i.Id,
                              ProdutoId = i.ProdutoId,
                              Quantidade = i.Quantidade,
                              Nome = i.Produto.Nome,
                              Preco = i.Produto.Preco

                          }).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }
    }
}
