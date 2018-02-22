using System;
using System.Threading.Tasks;

namespace AspNetCoreSoap.Contracts
{
    public interface IWhoIsRepository
    {
		Task<string> GetWhoIsForHostNameAsync(string hostName);
    }
}
