using BucketListTravel.Repository.Common;
using BucketListTravel.Repository.Contracts.Common;
using BucketListTravel.Services;
using BucketListTravel.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BucketListTravel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositoriesFromAssembly(this IServiceCollection serviceCollection,
            Assembly repositoryAssembly)
        {
            IEnumerable<Type> repositoryImplTypes = repositoryAssembly
                .GetTypes()
                .Where(t => t.BaseType != null &&
                            t.BaseType.IsGenericType &&
                            t.IsAbstract == false &&
                            (t.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>) ||
                             t.BaseType.GetGenericTypeDefinition() == typeof(BaseSoftDeletableRepository<>)))
                .ToArray();

            foreach (Type repositoryType in repositoryImplTypes)
            {
                Type? interfaceType = repositoryType
                    .GetInterfaces()
                    .SingleOrDefault(it => !it.IsGenericType &&
                                           it.GetInterfaces().Any(bit => bit.IsGenericType &&
                                                                         (bit.GetGenericTypeDefinition() ==
                                                                          typeof(IRepository<>) ||
                                                                          bit.GetGenericTypeDefinition() ==
                                                                          typeof(ISoftDeletableRepository<>))));


                if (interfaceType != null)
                {
                    serviceCollection.AddScoped(interfaceType, repositoryType);
                }
            }

            return serviceCollection;
        }

        public static IServiceCollection RegisterServicesFromAssembly(
            this IServiceCollection serviceCollection,
            Assembly serviceAssembly)
        {
            serviceCollection.AddScoped<IDestinationService, DestinationService>();
            serviceCollection.AddScoped<IBucketListService, BucketListService>();
            return serviceCollection;
        }
    }
}