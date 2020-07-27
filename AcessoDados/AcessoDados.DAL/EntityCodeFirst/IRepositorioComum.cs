using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public interface IRepositorioComum<T>
	{
		T Inserir(T modelo);

		List<T> Listar();

		void Excluir(T modelo);

		T Atualizar(T modelo);

		T Obter(int id);
	}
}
