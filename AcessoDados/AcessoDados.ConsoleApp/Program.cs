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
						
			Console.ReadKey();
		}
	}
}
