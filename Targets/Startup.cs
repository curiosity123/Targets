using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Targets.Controllers;
using Targets.Infrastructure;
using Targets.Infrastructure.EF;
using Targets.Infrastructure.Repositories;
using Targets.Infrastructure.Services;
using Targets.Infrastructure.Services.Interfaces;
using Targets.Settings;

namespace Targets
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
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);
            services.AddSingleton<IConfiguration>(Configuration);
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<TargetsContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectsService, ProjectService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IRepository, MsSqlRepository>();


            var jwtSection = Configuration.GetSection("jwt");
            var jwtOptions = new JwtSettings();
            jwtSection.Bind(jwtOptions);
            services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });
            services.Configure<JwtSettings>(jwtSection);


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
