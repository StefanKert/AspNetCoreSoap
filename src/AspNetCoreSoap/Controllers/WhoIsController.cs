using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSoap.Soap;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSoap.Controllers
{
	[Route("api/[controller]")]
    public class WhoIsController : Controller
    {
		private WhoIsSoapRepository _webService;

		public WhoIsController() {
			_webService = new WhoIsSoapRepository();
		}

        [HttpGet("{hostName}")]
		public async Task<IActionResult> Get(string hostName){
			var whoIsInfo = await _webService.GetWhoIsForHostNameAsync(hostName);
			return Ok(whoIsInfo);
		}
    }
}
