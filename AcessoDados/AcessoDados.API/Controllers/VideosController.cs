using System;
using System.Collections.Generic;
using AcessoDados.BLL.Services;
using AcessoDados.DL.API.Request;
using AcessoDados.DL.API.Response;
using Microsoft.AspNetCore.Mvc;

namespace AcessoDados.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideosController : ControllerBase
	{

		private VideoService _svc;
		public VideosController(VideoService svc)
		{
			_svc = svc;
		}

		[HttpGet]
		public ActionResult<List<VideoResponseModel>> Get()
		{
			return _svc.Listar();
		}

		[HttpPost]
		public ActionResult<VideoResponseModel> Post(VideoCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				var retorno = _svc.InserirVideo(model);

				if (retorno != null)
					return Ok(retorno);
				else
					return BadRequest();
			}

			return BadRequest(ModelState);
		}
	}
}
