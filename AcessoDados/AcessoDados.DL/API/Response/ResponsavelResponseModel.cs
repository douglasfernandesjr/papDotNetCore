using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DL.API.Response
{
	public class ResponsavelResponseModel
	{
		public ResponsavelResponseModel(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public int Id { get; set; }

		public string Nome { get; set; }
	}
}
