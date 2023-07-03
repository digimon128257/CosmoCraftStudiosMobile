using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyFinanceLoan.Mobile.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace EasyFinanceLoan.Mobile.ViewModel
{
    public partial class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _userName;

        public string userName 
        { 
            get { return this._userName; } 
            set 
            {
                this._userName = value;
                if (this.userName.Length == 0)
                {
                    this.errorText = "UserName is required";
                   this.hasError = true;
                }
                else
                {
                    this.errorText = "";
                    this.hasError = false;
                }
                OnpropertyChanged(nameof(errorText));
                OnpropertyChanged(nameof(hasError));
            }
        }
        public string password { get; set; } 
        public string errorText { get; set; }
        public bool hasError { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnpropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [RelayCommand]

        async Task GoToLoan1(LoginViewModel model)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true; // **** Always accept
            };
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback +=
                            (sender, certificate, chain, errors) =>
                            {
                                return true;
                            };
            if (model == null)
                return;
            HttpClient httpClient = new HttpClient();
        var response = await httpClient.GetFromJsonAsync<List< WeatherForecast>>("https://ce58-47-35-180-19.ngrok.io/WeatherForecast");
            await Shell.Current.GoToAsync(nameof(Loan1), true, new Dictionary<string, object>
        {
            {"Login", model }
        });
        }
    }
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
