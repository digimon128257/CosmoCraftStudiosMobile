using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace EasyFinanceLoan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTransaction")]
        public IEnumerable<Transaction> Get()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("KioskAdmin");
            var c = new SqlConnection(connectionString);
            c.Open();
            var s = "select * from dbo.Transactions";
            using (SqlCommand cmdSQL = new SqlCommand(s, c))
            {
                var r = cmdSQL.ExecuteReader();
                var t = new List<Transaction>();
                while (r.Read())
                {
                    t.Add(new Transaction
                    {
                        Id = r.GetInt64("Id"),
                        GroupId = r.GetInt32("GroupId"),
                        TransType = r.GetInt32("TransType"),
                        Amount = r.GetDecimal("Amount"),
                        Remark = r.GetString("Remark")
                    });
                }
                t.Add(new Transaction()
                {
                    Amount = 1,
                    GroupId = 1,
                    Id = 0,
                    Remark = "test2 ",
                    TransType = 1
                });
                return t;
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