using EasyFinanceLoan.Mobile.ViewModel;

namespace EasyFinanceLoan.Mobile;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	if(nameValidattor.IsNotValid)
	//	{
	//		DisplayAlert("Hello World", "ok", "ok2");
	//	}
	//	count++;

	//	//SemanticScreenReader.Announce(CounterBtn.Text);
	//}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
    }
}

