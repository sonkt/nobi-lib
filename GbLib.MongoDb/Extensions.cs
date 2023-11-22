using GbLib.Base;
using GbLib.MongoDb.Context;
using GbLib.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace GbLib.MongoDb
{
    public static class Extensions
    {
        public static async Task<(int totalPages, long totalRows, IReadOnlyList<TDocument> data)> AggregateByPage<TDocument>(
               this IMongoCollection<TDocument> collection,
               FilterDefinition<TDocument> filterDefinition,
               SortDefinition<TDocument> sortDefinition,
               int page,
               int pageSize)
        {
            var countFacet = AggregateFacet.Create("count",
                PipelineDefinition<TDocument, AggregateCountResult>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Count<TDocument>()
                }));

            var dataFacet = AggregateFacet.Create("data",
                PipelineDefinition<TDocument, TDocument>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Sort(sortDefinition),
                PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
                PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize),
                }));

            var aggregation = await collection.Aggregate(new AggregateOptions { AllowDiskUse = true })
                .Match(filterDefinition)
                .Facet(countFacet, dataFacet)
                .ToListAsync();

            var count = aggregation.First()
                .Facets.First(x => x.Name == "count")
                .Output<AggregateCountResult>()
                ?.FirstOrDefault()
                ?.Count;

            var totalPages = count == null ? 0 : (int)Math.Ceiling((double)count / pageSize);

            var data = aggregation.First()
                .Facets.First(x => x.Name == "data")
                .Output<TDocument>();

            return (totalPages, count == null ? 0 : count.Value, data);
        }

        public static IServiceCollection AddMongoRepository(this IServiceCollection services)
        {
            services.AddAppSettings<MongoDbOptions>("Mongo");
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            return services;
        }

        public static IServiceCollection AddRepositories<T>(this IServiceCollection services) where T : class
        {
            services.Scan(scan => scan
            .FromAssemblyOf<T>()
                 .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            return services;
        }
    }
}