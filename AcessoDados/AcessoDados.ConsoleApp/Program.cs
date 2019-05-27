﻿using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DAL.EntityDBFirst;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var context = new CodeFirstDBContext();

			List<Video> resultadoLista = context.Video.Take(50).ToList();

			foreach (var col in resultadoLista)
			{
				Console.WriteLine($"{col.IdVideo}");
			}

			Console.ReadKey();
		}
	}
}
