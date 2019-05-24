using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst.Modelos
{
	public class Categoria : EntidadeBancoBase
	{
		[Key]
		public int IdCategoria { get; set; }

		[Required]
		[StringLength(255)]
		public string Nome { get; set; }

		public virtual ICollection<VideoCategoria> VideoCategorias { get; set; }
	}
}
