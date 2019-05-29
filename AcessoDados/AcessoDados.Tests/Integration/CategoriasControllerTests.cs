using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AcessoDados.Tests.Integration
{
	public class CategoriasControllerTests : IClassFixture<WebApplicationFactory<API.Startup>>
	{
		private readonly WebApplicationFactory<API.Startup> _factory;

		public CategoriasControllerTests(WebApplicationFactory<API.Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task Get_Categorias()
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync("/api/categorias");

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			string responseString = await response.Content.ReadAsStringAsync();

			Assert.True(responseString.Length > 0);
		}
	}
}
