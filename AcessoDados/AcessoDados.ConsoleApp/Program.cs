using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DAL.EntityDBFirst;
using System;
using System.Linq;

namespace AcessoDados.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//É possível usar através de um repositório criado por herança.
			var repositorioCat = new RepositorioCategoria();

			foreach (var col in repositorioCat.Listar())
			{
				Console.WriteLine($"{col.Nome}");
			}

			//É possível usar através de instáncia direta
			var repResponsavel = new RepositorioComum<Responsavel>();

			repResponsavel.Inserir(new Responsavel()
			{ Nome = "Douglas", UsuarioCriacao = "Admin", DataCriacao = DateTime.Now });

			//É possível usar através de extensões

			var repVideo = new RepositorioVideos();

			var novoVideo = repVideo.InserirVideo(
				new Video()
				{
					Url = "https://www.youtube.com/watch?v=oowBXzfcl90",
					Titulo = "Primeiro Vídeo",
					IdadeMinima = 14,
					IdResponsavel = 1,
					UsuarioCriacao = "Admin",
					DataCriacao = DateTime.Now
				},
				new int[] { 1, 2 });


			Console.ReadKey();
		}
	}
}
