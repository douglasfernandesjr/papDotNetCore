using AcessoDados.DAL.EntityCodeFirst.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class RepositorioCategoria
	{
		public Categoria Inserir(Categoria categoria)
		{
			using (var db = new CodeFirstDBContext())
			{
				db.ChangeTracker.AutoDetectChangesEnabled = false;

				db.Categoria.Add(categoria);

				db.SaveChanges();

				return categoria;
			}
		}

		public List<Categoria> Listar() {
			using (var db = new CodeFirstDBContext())
			{
				return db.Categoria.ToList();
			}
		}
	}
}
