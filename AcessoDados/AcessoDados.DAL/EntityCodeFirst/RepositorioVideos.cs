using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class RepositorioVideos : RepositorioComum<Video>
	{
		public Video InserirVideo(Video modelo, int[] idCategorias) {

			this.Inserir(modelo);

			if (idCategorias != null)
			{
				var repVideoCategoria = new RepositorioComum<VideoCategoria>();

				foreach (int id in idCategorias)
					repVideoCategoria.Inserir(new VideoCategoria()
					{
						IdVideo = modelo.IdVideo,
						IdCategoria = id,
						UsuarioCriacao = "admin",
						DataCriacao = DateTime.Now
					});

			}

			return ObterVideoCompleto(modelo.IdVideo);
		}

		public Video ObterVideoCompleto(int id) {
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
	}
}
