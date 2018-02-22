using AspNetCoreSoap.Soap.WhoIsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSoap.Soap
{
	public class WhoIsSoapRepository
	{
		private readonly string _url;

		public WhoIsSoapRepository() : this("http://www.webservicex.net/whois.asmx") {

		}

		public WhoIsSoapRepository(string url) {
			this._url = url;
		}
	
		public async Task<string> GetWhoIsForHostNameAsync(string hostName){
			var client = new whoisSoapClient(new BasicHttpBinding(), new EndpointAddress(_url));
			return await client.GetWhoISAsync(hostName);
		}
	}
}
