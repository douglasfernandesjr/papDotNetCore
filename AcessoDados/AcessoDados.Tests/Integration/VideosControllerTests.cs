using AcessoDados.DL.API.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AcessoDados.Tests.Integration
{
	public class VideosControllerTests : IClassFixture<WebApplicationFactory<API.Startup>>
	{
		private readonly WebApplicationFactory<API.Startup> _factory;

		public VideosControllerTests(WebApplicationFactory<API.Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task Get_Videos()
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync("/api/videos");

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			string responseString = await response.Content.ReadAsStringAsync();

			Assert.True(responseString.Length > 0);
		}

		[Fact]
		public async Task Post_Videos_Empty()
		{
			var client = _factory.CreateClient();

			var response = await client.PostAsync("/api/videos", null);

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

		public static IEnumerable<object[]> PostVideosTheoryData()
		{
			var allData = new List<object[]>
			{
			new object[] {
				new VideoCreateRequest(),
				HttpStatusCode.BadRequest
				},
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7
				},
				HttpStatusCode.BadRequest
				},
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título" }
				,
				HttpStatusCode.BadRequest
				},
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
				},
				HttpStatusCode.BadRequest
				}
			,
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
					IdResponsavel = -1
				},
				HttpStatusCode.BadRequest
				}
			,
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
					IdResponsavel = 1
				},
				HttpStatusCode.OK
				}
			,
			new object[] {
				new VideoCreateRequest(){
					IdadeMinima = 7,
					Titulo = "Título",
					Url = "URL",
					IdResponsavel = 1,
					ListaCategorias = new int[]{ 1}
				},
				HttpStatusCode.BadRequest
				}
			}
			;

			return allData;
		}

		[Theory]
		[MemberData(nameof(PostVideosTheoryData))]
		public async Task Post_Videos_Theory(VideoCreateRequest model, HttpStatusCode statusCode)
		{
			var jsonString = JsonConvert.SerializeObject(model);

			// Wrap our JSON inside a StringContent which then can be used by the HttpClient class
			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

			var client = _factory.CreateClient();

			var response = await client.PostAsync("/api/videos", httpContent);

			Assert.Equal(statusCode, response.StatusCode);
		}
	}
}