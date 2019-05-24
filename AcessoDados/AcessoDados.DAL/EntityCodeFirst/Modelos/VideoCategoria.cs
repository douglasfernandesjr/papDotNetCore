using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst.Modelos
{
	public class VideoCategoria : EntidadeBancoBase
	{
		[Key]
		public int IdVideoCategoria { get; set; }

		[Required]
		public int IdCategoria { get; set; }

		[Required]
		public int IdVideo { get; set; }

		public virtual Categoria Categoria { get; set; }

		public virtual Video Video { get; set; }
	}
}
