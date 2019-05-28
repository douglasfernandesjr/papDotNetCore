﻿using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class RepositorioComum<T> where T : EntidadeBancoBase, new()
	{
		public T Inserir(T modelo)
		{
			using (var db = new CodeFirstDBContext())
			{
				db.ChangeTracker.AutoDetectChangesEnabled = false;

				db.Set<T>().Add(modelo);

				db.SaveChanges();

				return modelo;
			}
		}

		public List<T> Listar()
		{
			using (var db = new CodeFirstDBContext())
			{
				return db.Set<T>().Where(x=>!x.FlagExcluido).ToList();
			}
		}

		public void Excluir(T modelo)
		{
			using (var db = new CodeFirstDBContext())
			{
				modelo.FlagExcluido = true;
				Atualizar(modelo);	
			}
		}

		public T Atualizar(T modelo) {
			using (var db = new CodeFirstDBContext())
			{
				db.ChangeTracker.AutoDetectChangesEnabled = false;

				db.Entry(modelo).State = EntityState.Modified;

				db.SaveChanges();

				return modelo;
			}
		}
	}
}