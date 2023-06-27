using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Google.Crypto.Tink.Mac;

namespace EasyFinanceLoan.Mobile.ViewModel
{
    [QueryProperty(nameof(Login), "Login")]
    partial class Loan1ViewModel : BaseViewModel
    {
        public Loan1ViewModel()
        {
            dob = DateTime.Today.AddYears(-25);
        }

        [ObservableProperty]
        public LoginViewModel login;

        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime dob { get; set; }
        public string sex { get; set; }
        public string trn { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string eMail { get; set; }
        public string contact { get; set; }
        public string idType { get; set; }
        public string idNumber { get; set; }
        public string issueDate { get; set; }
        public string expDate { get; set; }
        public string password { get; set; }
        public string confirm { get; set; }
    }
}
