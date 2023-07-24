namespace EasyFinanceLoan.Mobile.CustomControls;

public partial class OutliinedSelectControl : Grid
{
    public OutliinedSelectControl()
    {
        InitializeComponent();
        lblPlaceholder.FontSize = 12;
        lblPlaceholder.TranslateTo(0, -28, 80, easing: Easing.Linear);
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        propertyName: nameof(SelectedItem),
        returnType: typeof(string),
        declaringType: typeof(OutliinedSelectControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );
    public string SelectedItem
    {
        get => (string)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly BindableProperty ItemSourcesProperty = BindableProperty.Create(
        propertyName: nameof(ItemSources),
        returnType: typeof(List<string>),
        declaringType: typeof(OutliinedSelectControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public List<string> ItemSources
    {
        get => (List<string>)GetValue(ItemSourcesProperty);
        set => SetValue(ItemSourcesProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(OutliinedSelectControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    private void SelEntry_Focused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ff00ff00");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.Bold;
    }

    private void SelEntry_Unfocused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ffaaaaaa");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.None;
    }
}