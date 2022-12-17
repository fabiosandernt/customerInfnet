
using Customer.Domain.Account.Repository;
using Customer.Domain.Cadastro.Repository;
using Customer.Repository.Context;
using Customer.Repository.Database;
using Customer.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Customer.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CustomerContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });
            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;
        }
    }
}
