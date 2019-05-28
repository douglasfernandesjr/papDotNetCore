using System;
using System.Collections.Generic;
using AcessoDados.BLL.Services;
using AcessoDados.DL.API.Response;
using Microsoft.AspNetCore.Mvc;

namespace AcessoDados.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		[HttpGet]
		public List<CategoriaResponseModel> Get() {
			var svc = new CategoriaService();
			return svc.ListarCategorias();
		}
	}
}