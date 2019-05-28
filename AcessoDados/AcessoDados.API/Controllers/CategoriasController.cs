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
		private CategoriaService _svc;
		public CategoriasController(CategoriaService svc)
		{
			_svc = svc;
		}

		[HttpGet]
		public List<CategoriaResponseModel> Get() {
			return _svc.ListarCategorias();
		}
	}
}