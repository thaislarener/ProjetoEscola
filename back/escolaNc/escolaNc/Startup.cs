using escolaNc.Data;
using escolaNc.Interfaces;
using escolaNc.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace escolaNc
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "escolaNc", Version = "v1" });
            });

            services.AddDbContext<EscolaContext>(
                context => context
                .UseSqlServer(Configuration.GetConnectionString("Default"))
            );
            services.AddCors();
            services.AddTransient<IUsuariosService, UsuariosService>();
            services.AddTransient<IServicoService, ServicoService>();
            services.AddTransient<IContratacaoService, ContratacaoService>();
            services.AddTransient<IRelatoriosService, RelatoriosService>();
            services.AddTransient<IAcessoBD, AcessoBD>();
            services.AddTransient<ILoginService, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "escolaNc v1"));
            }

            app.UseCors(
                x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
