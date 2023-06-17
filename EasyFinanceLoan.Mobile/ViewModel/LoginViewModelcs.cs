using CommunityToolkit.Mvvm.ComponentModel;
using EasyFinanceLoan.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace EasyFinanceLoan.Mobile.ViewModel
{
    public  class LoginViewModelcs : BaseViewModel
    {
        public Login Login { get; } = new();

    }
}
