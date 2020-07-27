using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DL.API.Response;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados.BLL.Services
{
	public class CategoriaService
	{
		private IRepositorioComum<Categoria> _repositorio;

		public CategoriaService(IRepositorioComum<Categoria> repositorio)
		{
			_repositorio = repositorio;
		}

		public List<CategoriaResponseModel> ListarCategorias()
		{
			var listaRetorno = new List<CategoriaResponseModel>();  // cria uma lista vazia

			var lista = _repositorio.Listar();

			if (lista != null && lista.Any())
			{
				foreach (Categoria item in lista)
					listaRetorno.Add(new CategoriaResponseModel(item.IdCategoria, item.Nome));
			}

			return listaRetorno;
		}
	}
}