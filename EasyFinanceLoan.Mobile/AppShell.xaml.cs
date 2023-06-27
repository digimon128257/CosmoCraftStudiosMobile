using EasyFinanceLoan.Mobile.View;

namespace EasyFinanceLoan.Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Loan1), typeof(Loan1));
	}
}
