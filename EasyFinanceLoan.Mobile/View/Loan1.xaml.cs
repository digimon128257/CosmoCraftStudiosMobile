using AndroidX.Lifecycle;
using CommunityToolkit.Mvvm.ComponentModel;
using EasyFinanceLoan.Mobile.ViewModel;
using Xamarin.Google.Crypto.Tink.Mac;

namespace EasyFinanceLoan.Mobile.View;

public partial class Loan1 : ContentPage
{
    Loan1ViewModel _loan1;
    LoginViewModel _login; 
	public Loan1(LoginViewModel login)
	{
        _login = login;
		InitializeComponent();  
        _loan1 = new Loan1ViewModel();
        BindingContext = _loan1;
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        var a = 1;
    }
}