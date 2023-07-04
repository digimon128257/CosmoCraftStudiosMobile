using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace EasyFinanceLoan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
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
            }

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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