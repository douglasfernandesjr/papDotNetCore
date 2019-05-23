using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AcessoDados.DAL.AdoNet
{
	public class ConexaoSimples
	{
		private readonly string connectionString = "<SUA CONEXÂO AQUI!>";

		public List<CustomerSQLModel> ListarColaboradores()
		{
			using (var conn = new SqlConnection(connectionString))
			{
				var sql = @"select top 50 [Id],[FirstName],[LastName],[City],[Country],[Phone] from [Customer];";

				conn.Open();

				using (var cmd = new SqlCommand(sql, conn))
				{
					SqlDataReader dataReader = cmd.ExecuteReader();
					var dataTable = new DataTable();
					dataTable.Load(dataReader);

					var lista = new List<CustomerSQLModel>();

					foreach (DataRow row in dataTable.Rows)
					{
						var colaborador = new CustomerSQLModel();
						colaborador.Id = (int)row["Id"];
						colaborador.FirstName = (string)row["FirstName"];
						colaborador.LastName = (string)row["LastName"];
						colaborador.City = (string)row["City"];
						colaborador.Country = (string)row["Country"];
						colaborador.Phone = (string)row["Phone"];

						lista.Add(colaborador);
					}

					return lista;
				}
			}
		}
	}
}
