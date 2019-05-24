using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst.Modelos
{
	public class Video: EntidadeBancoBase
	{
		[Key]
		public int IdVideo { get; set; }

		[Required]
		[StringLength(255)]
		public string Titulo { get; set; }

		[Required]
		[StringLength(255)]
		public string Url { get; set; }

		public int? IdadeMinima { get; set; }

		[Required]
		public int IdResponsavel { get; set; }

		public virtual Responsavel Responsavel { get; set; }

		public virtual ICollection<VideoCategoria> VideoCategorias { get; set; }
	}
}
