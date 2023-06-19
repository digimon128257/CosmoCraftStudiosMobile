using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
                Debug.WriteLine("12345");
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
        async Task GetMonkeysAsync()
        {
            this.userName = "test23456";
            this.password = "rrrrr";
            this.errorText = "Hello World";
            var a = 1;
            OnpropertyChanged(nameof(userName));
            OnpropertyChanged(nameof(password));
            OnpropertyChanged(nameof(errorText));
        }

    }
}
