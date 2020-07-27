using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class RepositorioVideos : RepositorioComum<Video>, IRepositorioVideos
	{
		private RepositorioComum<VideoCategoria> _repoVideoCategoria;

		public RepositorioVideos(IPrincipal currentUser, RepositorioComum<VideoCategoria> repoVideoCategoria)
			: base(currentUser)
		{
			_repoVideoCategoria = repoVideoCategoria;
		}

		public Video InserirVideo(Video modelo, int[] idCategorias)
		{
			this.Inserir(modelo);

			if (idCategorias != null)
			{
				foreach (int id in idCategorias)
					_repoVideoCategoria.Inserir(new VideoCategoria()
					{
						IdVideo = modelo.IdVideo,
						IdCategoria = id,
					});
			}

			return ObterVideoCompleto(modelo.IdVideo);
		}

		public Video ObterVideoCompleto(int id)
		{
			using (var db = new CodeFirstDBContext())
			{
				//Define que será realizada uma pesquisa pelo campo ID
				IQueryable<Video> query = db.Video.Where(x => x.IdVideo == id);

				//Indica que deve trazer a entidade Responsável
				query = query.Include(x => x.Responsavel);

				//Indica de deve trazer a Entidade Categoria associada através da VideoCategoria
				query = query.Include("VideoCategorias.Categoria");

				return query.FirstOrDefault();
			}
		}

		public List<Video> ListarVideosCompletos()
		{
			using (var db = new CodeFirstDBContext())
			{
				IQueryable<Video> query = db.Video.Where(x => !x.FlagExcluido);

				//Indica que deve trazer a entidade Responsável
				query = query.Include(x => x.Responsavel);

				//Indica de deve trazer a Entidade Categoria associada através da VideoCategoria
				query = query.Include("VideoCategorias.Categoria");

				return query.ToList();
			}
		}
	}
}