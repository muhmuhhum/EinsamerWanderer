using AutoMapper;
using EinsamerWanderer.API.DbContext;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Store;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EinsamerWanderer.API
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
            services.AddDbContext<EinsamerWandererDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IItemManager, ItemManager>();
            services.AddScoped<IItemStore, ItemStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Einsamer Wanderer");
            });

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors(
                    options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
                );
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
        }
    }
}
