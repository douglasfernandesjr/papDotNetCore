using AcessoDados.BLL.Services;
using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AcessoDados.Tests.Unit
{
	public class CategoriaServiceTests : BLLServiceTestBase
	{
		private CategoriaService _service;

		public CategoriaServiceTests()
		{
			//será necessário resolver as dependências manualmente instânciar
			//nos permitindo mockar dados
			var repo = new RepositorioComum<Categoria>(base.GetMockUser());
			_service = new CategoriaService(repo);

		}

		[Fact]
		public void ListarCategorias()
		{
			var result = _service.ListarCategorias();

			Assert.True(result.Any());
		}
	}
}
