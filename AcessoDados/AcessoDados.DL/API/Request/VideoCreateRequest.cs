using System;
using System.ComponentModel.DataAnnotations;

namespace AcessoDados.DL.API.Request
{
	public class VideoCreateRequest
	{
		[Required]
		[StringLength(255)]
		public string Titulo { get; set; }

		[Required]
		[StringLength(255)]
		public string Url { get; set; }

		public int? IdadeMinima { get; set; }

		[Required]
		public int IdResponsavel { get; set; }

		public int[] ListaCategorias { get; set; }
	}
}
