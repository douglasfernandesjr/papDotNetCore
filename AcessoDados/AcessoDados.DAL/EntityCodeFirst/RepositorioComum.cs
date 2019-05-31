using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class RepositorioComum<T> where T : EntidadeBancoBase, new()
	{
		protected IPrincipal _user;
		public RepositorioComum(IPrincipal currentUser)
		{
			_user = currentUser;
		}

		protected virtual void AtualizarValoresPadroes(T modelo) {
			modelo.UsuarioCriacao = _user.Identity.Name == null ? "admin" : _user.Identity.Name;
			modelo.DataCriacao = DateTime.Now;
		}

		public T Inserir(T modelo)
		{
			using (var db = new CodeFirstDBContext())
			{
				db.ChangeTracker.AutoDetectChangesEnabled = false;
				AtualizarValoresPadroes(modelo);
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

		public T Obter(int id)
		{
			using (var db = new CodeFirstDBContext())
			{
				return db.Set<T>().Find(id);
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
