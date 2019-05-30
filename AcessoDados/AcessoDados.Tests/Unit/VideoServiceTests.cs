using AcessoDados.BLL.Services;
using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DL.API.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AcessoDados.Tests.Unit
{
	public class VideoServiceTests : BLLServiceTestBase
	{
		private VideoService _service;

		public VideoServiceTests()
		{
			//será necessário resolver as dependências manualmente instânciar
			//nos permitindo mockar dados
			var repo = new RepositorioVideos(base.GetMockUser(),
			new RepositorioComum<VideoCategoria>(base.GetMockUser()),
			new RepositorioComum<Responsavel>(base.GetMockUser()));
			_service = new VideoService(repo);

		}

		[Fact]
		public void ListarVideos()
		{
			var result = _service.Listar();

			Assert.True(result.Any());
		}

		[Fact]
		public void InserirVideo_Vazio()
		{
			var result = _service.InserirVideo(null);

			Assert.Null(result);
		}

		public static IEnumerable<object[]> PostVideosTheoryData()
		{
			var allData = new List<object[]>
			{
			new object[] {
				null,
				true
				},
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
					IdResponsavel = 1,
					ListaCategorias = new int[]{ 1}
				},
				false
				},
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
					IdResponsavel = 1,
					ListaCategorias = new int[]{ 100000,1233455}
				},
				false
				}
			}
			;

			return allData;
		}

		[Theory]
		[MemberData(nameof(PostVideosTheoryData))]
		public void InserirVideo_Vazio_Theory(VideoCreateRequest model, bool equalsNull)
		{
			var result = _service.InserirVideo(model);

			Assert.True((result == null) == equalsNull);
		}
	}
}
