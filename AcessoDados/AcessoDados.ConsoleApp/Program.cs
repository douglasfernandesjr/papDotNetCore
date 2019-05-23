using AcessoDados.DAL.AdoNet;
using System;

namespace AcessoDados.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var conexao = new ConexaoSimples();

			foreach (var col in conexao.ListarColaboradores())
			{
				Console.WriteLine($"{col.Id}\t{col.FirstName}\t{col.LastName} ");
			}

			Console.ReadKey();
		}
	}
}
