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
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto do banco
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Adiciona um novo cliente no banco de dados
        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            var result = await _context.Clientes.AddAsync(cliente);  // Adiciona cliente à tabela 'Clientes'
            var isSave = await _context.SaveChangesAsync();          // Salva as mudanças no banco de dados
            if (isSave == 1)
            {
                return result.Entity;
            }

            return new Cliente();
        }

            // Deleta um cliente pelo ID
            public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id); // Encontra o cliente pelo ID
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente); // Remove o cliente do banco de dados
                await _context.SaveChangesAsync(); // Salva as mudanças
            }
        }

        // Obtém todos os clientes
        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync(); // Retorna todos os clientes
        }

        // Obtém um cliente pelo ID
        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id); // Retorna o cliente com o ID especificado
        }

        // Atualiza um cliente no banco de dados
        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);  // Atualiza o cliente na tabela 'Clientes'
            await _context.SaveChangesAsync();  // Salva as mudanças
        }
    }
}
