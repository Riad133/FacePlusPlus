using System;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace FacePlusPlus.Web.Extentions
{
    public static class SerilogExtensions
    {
        public static IHostBuilder SetupSerilog(this IHostBuilder builder,string indexName)
        {
            return builder.UseSerilog(((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .Enrich.WithProcessId()
                    .Enrich.WithProcessName()
                    .Enrich.WithThreadId()
                    .WriteTo.Elasticsearch(
                        new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticSearch:Server"]))
                        {
                            IndexFormat = $"{indexName}_{DateTime.UtcNow:yyyy.MM.dd}",
                            AutoRegisterTemplate = true,
                            NumberOfShards = 2,
                            NumberOfReplicas = 1
                        })
                    .ReadFrom.Configuration(context.Configuration);
            }));
        }
    }
}