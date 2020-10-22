using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using EinsamerWanderer.API.DbContext;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Store;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace EinsamerWanderer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddScheme<JwtBearerOptions,JwtTokenHandler>(JwtBearerDefaults.AuthenticationScheme,options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        SignatureValidator =  new SignatureValidator((token, parameters) => new JwtSecurityTokenHandler().ReadToken(token)),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });

            services.AddDbContext<EinsamerWandererDbContext>(opt =>
            {
                opt.UseLoggerFactory(MyLoggerFactory);
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                opt.EnableSensitiveDataLogging(true);
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

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
        }
    }
}
