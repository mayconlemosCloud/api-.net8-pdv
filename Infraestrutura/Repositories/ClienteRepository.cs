using Aplicacao.Interfaces;
using Dominio.Entities;
using Dominio.Validators;
using FluentValidation.Results;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        private readonly ClienteValidator _clienteValidator;

        private readonly IResult<Cliente> _result;

        // Construtor que injeta o contexto do banco
        public ClienteRepository(AppDbContext context, ClienteValidator clienteValidator, IResult<Cliente> result)
        {
            _context = context;
            _clienteValidator = clienteValidator;
            _result = result;

        }

        public async Task<ValidationResult> Validation(Cliente cliente)
        {
            return await _clienteValidator.ValidateAsync(cliente);
        }

        // Adiciona um novo cliente no banco de dados
        public async Task<IResult<Cliente>> AddAsync(Cliente cliente)
        {
            var validate = await Validation(cliente);

            if (!validate.IsValid)
            {
                var errors = validate.Errors.Select(e => e.ErrorMessage).ToList();
                return _result.ValidationFailure(errors);
            }

            var result = await _context.Clientes.AddAsync(cliente);  // Adiciona cliente à tabela 'Clientes'
            var isSave = await _context.SaveChangesAsync();          // Salva as mudanças no banco de dados
            if (isSave == 1)
            {
                return _result.SuccessResult(result.Entity);
            }

            return _result.ErrorResult("Erro ao salvar o cliente no banco de dados.");
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
