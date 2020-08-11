using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MongoManagerApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongo<TModel, TServiceImplementation>(this IServiceCollection services, Func<IServiceProvider, TServiceImplementation> config) 
            where TModel : class 
            where TServiceImplementation : MongoService<TModel> =>
            services.AddSingleton<MongoService<TModel>, TServiceImplementation>(config);
    }
}
