using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EasyFinanceLoan.Mobile.Services
{
    public class GenericService
    {
        public async Task<List<Transaction>> GetTransactions()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<Transaction>>("https://c00c-47-35-180-19.ngrok.io/Transaction");
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
