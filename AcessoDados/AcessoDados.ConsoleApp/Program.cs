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
			var repositorio = new RepositorioCategoria();

			repositorio.Inserir(new Categoria() { Nome = "Categoria 1", DataCriacao = DateTime.Now, UsuarioCriacao = "Douglas" });

			foreach (var col in repositorio.Listar())
			{
				Console.WriteLine($"{col.Nome}");
			}

			Console.ReadKey();
		}
	}
}
