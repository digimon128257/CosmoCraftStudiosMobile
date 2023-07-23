namespace EasyFinanceLoan.Mobile.CustomControls;

public partial class OutliinedDateControl : Grid
{
    public OutliinedDateControl()
    {
        InitializeComponent();
        lblPlaceholder.FontSize = 12;
        lblPlaceholder.TranslateTo(0, -28, 80, easing: Easing.Linear);
    }

    public static readonly BindableProperty CDateProperty = BindableProperty.Create(
        propertyName: nameof(CDate),
        returnType: typeof(DateTime),
        declaringType: typeof(OutliinedDateControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );
    public DateTime CDate
    {
        get => (DateTime)GetValue(CDateProperty);
        set => SetValue(CDateProperty, value);
    }
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(OutliinedDateControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    private void dteEntry_Focused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ff00ff00");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.Bold;
    }

    private void dteEntry_Unfocused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ffaaaaaa");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.None;
    }
}