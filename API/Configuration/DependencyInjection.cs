using Aplicacao.Interfaces;
using Aplicacao.Result;
using Aplicacao.Services;
using Dominio.Entities;
using Dominio.Validators;
using Infraestrutura.Repositories;

namespace API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IItemVendaService, ItemVendaService>();
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ClienteValidator>();
            services.AddScoped<IResult<Cliente>, Result<Cliente>>();
        }
    }
}
