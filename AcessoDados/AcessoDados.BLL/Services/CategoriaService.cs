using AcessoDados.DAL.EntityCodeFirst;
using AcessoDados.DAL.EntityCodeFirst.Modelos;
using AcessoDados.DL.API.Response;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados.BLL.Services
{
	public class CategoriaService
	{
		public List<CategoriaResponseModel> ListarCategorias()
		{
			var listaRetorno = new List<CategoriaResponseModel>();  // cria uma lista vazia
			var repositorio = new RepositorioCategoria();

			var lista = repositorio.Listar();

			if (lista != null && lista.Any())
			{
				foreach (Categoria item in lista)
					listaRetorno.Add(new CategoriaResponseModel(item.IdCategoria, item.Nome));
			}

			return listaRetorno;
		}
	}
}