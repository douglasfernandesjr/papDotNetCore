using AcessoDados.DAL.EntityDBFirst;
using System;
using System.Linq;

namespace AcessoDados.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var context = new bancotesteContext();

			var resultadoLista = context.Customer.Take(50).ToList();

			foreach (var col in resultadoLista)
			{
				Console.WriteLine($"{col.Id}\t{col.FirstName}\t{col.LastName} ");
			}

			Console.ReadKey();
		}
	}
}
