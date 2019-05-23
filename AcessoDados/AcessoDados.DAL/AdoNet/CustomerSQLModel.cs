using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DAL.AdoNet
{
	public class CustomerSQLModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
	}
}
