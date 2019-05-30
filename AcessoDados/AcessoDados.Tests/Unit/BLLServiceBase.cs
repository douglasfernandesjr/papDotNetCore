using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AcessoDados.Tests.Unit
{
	public abstract class BLLServiceTestBase
	{
		public IPrincipal GetMockUser()
		{
			return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, "MockUser"),
				new Claim(ClaimTypes.NameIdentifier, "1"),
				new Claim("custom-claim", "example claim value"),
			}, "mock"));
		}
	}
}
