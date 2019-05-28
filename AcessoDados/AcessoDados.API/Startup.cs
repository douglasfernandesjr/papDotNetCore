using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using AcessoDados.BLL.Services;
using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AcessoDados.API
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

			//Disponibilizar o usuário logado através de DI
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IPrincipal>
				(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

			//Adiciona os repositórios
			services.AddScoped<RepositorioVideos>(); // Usa oespecifico
			services.AddScoped<RepositorioComum<Categoria>>(); // cria instâncias genericas
			services.AddScoped<RepositorioComum<Responsavel>>();// cria instâncias genericas
			services.AddScoped<RepositorioComum<VideoCategoria>>();// cria instâncias genericas


			//Adiciona os servicos
			services.AddTransient<CategoriaService>(); // Usa oespecifico

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info { Title = "Projeto Exemplo", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Exemplo V1");
			});
		}
	}
}
