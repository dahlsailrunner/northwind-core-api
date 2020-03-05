using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NorthwindApiSampler.Graph;
using NorthwindApiSampler.Interfaces;
using NorthwindApiSampler.Repositories;
using Npgsql;
using System.Data;

namespace NorthwindApiSampler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Data access
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddScoped<IDbConnection, NpgsqlConnection>(_ => 
                    new NpgsqlConnection(Configuration.GetConnectionString("NorthwindDatabase")));
            services.AddScoped<INorthwindRepository, NorthwindRepository>();

            // GraphQL
            services.AddScoped<NorthwindQuery>();
            services.AddScoped<NorthwindSchema>();
            services.AddGraphQL(o => o.ExposeExceptions = true)
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);

            // REST
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            //GraphQL
            app.UseGraphQL<NorthwindSchema>();           
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // REST
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
