using Fazenda.Domain.Entities;
using Fazenda.Domain.Interfaces.Repositories;
using Fazenda.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Fazenda.IoC
{
    public static class Injector
    {
        public static void RegisterInjection(IServiceCollection services)
        {
            //services.AddScoped<IAnimalRepository, AnimalRepository>();
            //services.AddScoped<ICompraGadoItemRepository, CompraGadoItemRepository>();
            //services.AddScoped<ICompraGadoRepository, CompraGadoRepository>();
            //services.AddScoped<IPecuaristaRepository, PecuaristaRepository>();
            services.AddScoped<AnimalRepository>();
            services.AddScoped<CompraGadoItemRepository>();
            services.AddScoped<CompraGadoRepository>();
            services.AddScoped<PecuaristaRepository>();
        }
    }
}
