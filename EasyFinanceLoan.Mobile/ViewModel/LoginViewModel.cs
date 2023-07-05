using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyFinanceLoan.Mobile.Services;
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
        GenericService _genericService;
        public LoginViewModel(GenericService genericService)
        {
            _genericService = genericService;
        }
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
            var response = await _genericService.GetTransactions();
            await Shell.Current.GoToAsync(nameof(Loan1), true, new Dictionary<string, object>
        {
            {"Login", model }
        });
        }
    }
}
