using CristianKulessa.Locadora.BackOffice.WebApi.Repositories;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CristianKulessa.Locadora.BackOffice.WebApi
{
    public static class Container
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBairroRepository, BairroRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<IUFRepository, UFRepository>();
        }
    }
}
