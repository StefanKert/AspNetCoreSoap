using System.Threading.Tasks;
using AspNetCoreSoap.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSoap.Controllers
{
	[Route("api/[controller]")]
    public class WhoIsController : Controller
    {
		private IWhoIsRepository _whoIsRepository;

		public WhoIsController(IWhoIsRepository whoIsRepository) {
			_whoIsRepository = whoIsRepository;
		}

        [HttpGet("{hostName}")]
		public async Task<IActionResult> Get(string hostName){
			var whoIsInfo = await _whoIsRepository.GetWhoIsForHostNameAsync(hostName);
			return Ok(whoIsInfo);
		}
    }
}
