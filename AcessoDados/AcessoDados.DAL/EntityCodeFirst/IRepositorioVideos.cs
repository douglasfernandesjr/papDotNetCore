using AcessoDados.DAL.EntityCodeFirst.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public interface IRepositorioVideos : IRepositorioComum<Video>
	{

		Video InserirVideo(Video modelo, int[] idCategorias);

		Video ObterVideoCompleto(int id);

		List<Video> ListarVideosCompletos();
	}
}
