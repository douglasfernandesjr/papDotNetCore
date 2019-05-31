using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DL.API.Response
{
	public class VideoResponseModel
	{
		public int Id { get; set; }

		public string Titulo { get; set; }

		public string Url { get; set; }

		public int? IdadeMinima { get; set; }

		public ResponsavelResponseModel Responsavel { get; set; }

		public virtual ICollection<CategoriaResponseModel> VideoCategorias { get; set; }
	}
}
