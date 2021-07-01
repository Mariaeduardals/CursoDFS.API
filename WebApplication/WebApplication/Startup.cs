using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Dominio.Services;
using WebApplication.Persistenses.Context;
using WebApplication.Persistenses.Repositories;
using WebApplication.Service;

namespace WebApplication
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
                 Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy(name:"ecommerce-policy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000/*").AllowAnyMethod().
                        WithHeaders(HeaderNames.ContentType ,"x-custom-header");
                });
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<AppDbContext>();
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "ECommerce", Version = "v1"}); });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<ICompanhiaRepository, CompanhiaRepository>();
            services.AddScoped<ICompanhiaService, CompanhiaService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<ICompraService, CompraService>();
            
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(typeof(Companhia));
            services.AddAutoMapper(typeof(Produto));
            services.AddAutoMapper(typeof(Compra));
            services.AddAutoMapper(typeof(Usuario));
            services.AddAutoMapper(typeof(Item));

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    var s = Encoding.UTF8.GetBytes(Configuration["SecurityKey"]);
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Issuer"],
                        ValidAudience = Configuration["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(s)
                    };

                    opt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = _ => Task.CompletedTask,
                        OnTokenValidated = _ => Task.CompletedTask
                    };
                });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("ecommerce-policy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               
            });
        }
    }
}
    