using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DL.API.Request;
using AcessoDados.DL.API.Response;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados.BLL.Services
{
	public class VideoService
	{
		private IRepositorioVideos _repositorio;

		public VideoService(IRepositorioVideos repositorio)
		{
			_repositorio = repositorio;
		}

		public VideoResponseModel InserirVideo(VideoCreateRequest model)
		{
			if (model == null)
				return null;

			var video = new Video()
			{
				IdResponsavel = model.IdResponsavel,
				IdadeMinima = model.IdadeMinima,
				Titulo = model.Titulo,
				Url = model.Url,
			};

			video = _repositorio.InserirVideo(video, model.ListaCategorias);

			return Converter(video);
		}

		public List<VideoResponseModel> Listar()
		{
			var response = new List<VideoResponseModel>();

			var lista = _repositorio.ListarVideosCompletos();

			if (lista != null && lista.Any())
			{
				foreach (var item in lista)
					response.Add(Converter(item));
			}

			return response;
		}

		private VideoResponseModel Converter(Video model)
		{
			if (model == null)
				return null;

			var response = new VideoResponseModel()
			{
				Id = model.IdVideo,
				IdadeMinima = model.IdadeMinima,
				Titulo = model.Titulo,
				Url = model.Url,
			};

			if (model.Responsavel != null)
				response.Responsavel = new ResponsavelResponseModel(model.Responsavel.IdResponsavel, model.Responsavel.Nome);

			response.VideoCategorias = new List<CategoriaResponseModel>();

			if (model.VideoCategorias != null && model.VideoCategorias.Any())
			{
				foreach (VideoCategoria item in model.VideoCategorias)
				{
					response.VideoCategorias.Add(new CategoriaResponseModel(item.Categoria.IdCategoria, item.Categoria.Nome));
				}
			}

			return response;
		}
	}
}