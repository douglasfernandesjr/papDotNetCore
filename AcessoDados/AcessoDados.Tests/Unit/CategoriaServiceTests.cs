using AcessoDados.BLL.Services;
using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Moq;
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


		[Fact]
		public void Deve_ListarCategoriasExistentes()
		{
			Mock<IRepositorioComum<Categoria>> mockRepo = new Mock<IRepositorioComum<Categoria>>();

			mockRepo.Setup(x => x.Listar())
			.Returns(new List<Categoria>() { new Categoria { Nome = "Nome", IdCategoria = 1 } });

			_service = new CategoriaService(mockRepo.Object);


			var result = _service.ListarCategorias();

			Assert.True(result.Any());
		}

		[Fact]
		public void Deve_RetornarListaVazia()
		{
			Mock<IRepositorioComum<Categoria>> mockRepo = new Mock<IRepositorioComum<Categoria>>();

			mockRepo.Setup(x => x.Listar())
			.Returns(new List<Categoria>());

			_service = new CategoriaService(mockRepo.Object);

			var result = _service.ListarCategorias();

			Assert.True(result != null);
			Assert.True(!result.Any());
		}

		[Fact]
		public void Deve_RetornarListaVazia2()
		{
			Mock<IRepositorioComum<Categoria>> mockRepo = new Mock<IRepositorioComum<Categoria>>();

			List<Categoria> listaNull = null;

			mockRepo.Setup(x => x.Listar()).Returns(listaNull);

			_service = new CategoriaService(mockRepo.Object);

			var result = _service.ListarCategorias();

			Assert.True(result != null);
			Assert.True(!result.Any());
		}
	}
}
