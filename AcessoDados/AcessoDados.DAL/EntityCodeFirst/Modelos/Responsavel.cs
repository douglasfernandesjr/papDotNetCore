using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst.Modelos
{
	public class Responsavel : EntidadeBancoBase
	{
		[Key]
		public int IdResponsavel { get; set; }

		[Required]
		[StringLength(255)]
		public int Nome { get; set; }

		public virtual ICollection<Video> Videos { get; set; }
	}
}
