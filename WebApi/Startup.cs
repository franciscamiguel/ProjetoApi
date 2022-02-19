using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contexto;
using WebApi.Entidades;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repositorio;

namespace WebApi
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


            services.AddDbContext<Context>
            (options => options.UseSqlServer("Data Source=LAPTOP-6JHREI2F\\SQLEXPRESS;Initial Catalog=CADASTRO_FRA;Integrated Security=True"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            services.AddSingleton<ICliente, RepositorioCliente>();
            services.AddSingleton<IEndereco, RepositorioEndereco>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<Cliente, ClienteViewModel>();

                cfg.CreateMap<EnderecoViewModel, Endereco>();
                cfg.CreateMap<Endereco, EnderecoViewModel>();

                cfg.CreateMap<ClienteUpdateViewModel, Cliente>();
                cfg.CreateMap<Cliente, ClienteUpdateViewModel>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }



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
