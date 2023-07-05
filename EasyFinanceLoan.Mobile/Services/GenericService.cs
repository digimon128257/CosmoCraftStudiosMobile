using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace EasyFinanceLoan.Mobile.Services
{
    public class GenericService
    {
        public async Task<List<Transaction>> GetTransactions()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == SslPolicyErrors.None)
                    {
                        return true;   //Is valid
                    }

                    if (cert.GetCertHashString() == "E5CE41BE6F81C5E25743077E7A9D3E10A5574C21")
                    {
                        return true;
                    }
                    return false;
                };

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    return await httpClient.GetFromJsonAsync<List<Transaction>>("https://192.168.1.2:8082/Transaction");
                }
            }
        }
    }
    public class Transaction
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public int TransType { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
    }
}
