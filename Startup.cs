using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FacePlusPlus.Application.Interfaces;
using FacePlusPlus.Infrastructure;
using FacePlusPlus.Web.Extentions;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OpenIddict.Validation.SystemNetHttp;

namespace FacePlusPlus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(
                    options => 
                    {
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        options.SerializerSettings.MaxDepth = 1;
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.UseCamelCasing(true);
                    });
            services.AddRouting(options => options.LowercaseUrls = true);
            // services.AddIdentity();
            // services.AddIdentityServer(Configuration.GetConnectionString("DefaultConnection"));
           
            services.AddSwagger("identity server", "Identity server microservice designed by manzur");
        
          
            services.AddScoped<IApplicationCacheStorage, DistributedCacheStorage>();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddFluentValidation();
            services.AddMvc();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("Redis:Server");
                options.InstanceName = Configuration.GetValue<string>("Redis:Database");
            });
            
            services.AddHttpClient(typeof(OpenIddictValidationSystemNetHttpOptions).Assembly.GetName().Name)
                .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
                {
                    // ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("AdminClientApp:Url"));
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

            app.UseRequestResponseLogging();

            app.UseExceptionFormatting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
