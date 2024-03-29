using CommunityToolkit.Maui.Behaviors;

namespace EasyFinanceLoan.Mobile.CustomControls;

public partial class OutliinedEntryControl : Grid
{
	public OutliinedEntryControl()
	{
		InitializeComponent();
        lblPlaceholder.FontSize = 12;
        lblPlaceholder.TranslateTo(0, -28, 80, easing: Easing.Linear);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text),
		returnType: typeof(string),
		declaringType: typeof(OutliinedEntryControl),
		defaultValue:null,
		defaultBindingMode: BindingMode.TwoWay
		);
	public string Text
	{
		get => ( string )GetValue( TextProperty );
		set => SetValue( TextProperty, value );
	}

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        propertyName: nameof(IsPassword),
        returnType: typeof(bool),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty IsReadOnlyEntryProperty = BindableProperty.Create(
        propertyName: nameof(IsReadOnlyEntry),
        returnType: typeof(bool),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public bool IsReadOnlyEntry
    {
        get => (bool)GetValue(IsReadOnlyEntryProperty);
        set {
            SetValue(IsReadOnlyEntryProperty, value);
        } 
    }

    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(
        propertyName: nameof(KeyboardType),
        returnType: typeof(Keyboard),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    public static readonly BindableProperty EntryBackColorProperty = BindableProperty.Create(
        propertyName: nameof(EntryBackColor),
        returnType: typeof(Color),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public Color EntryBackColor
    {
        get => (Color)GetValue(EntryBackColorProperty);
        set => SetValue(EntryBackColorProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextMaskProperty = BindableProperty.Create(
        propertyName: nameof(TextMask),
        returnType: typeof(string),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
        );
    public string TextMask
    {
        get => (string)GetValue(TextMaskProperty);
        set => SetValue(TextMaskProperty, value);
    }

    private void txtEntry_Focused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ffaaffaa");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.Bold;
    }

    private void txtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ffaaaaaa");
        bdrOuter.StrokeThickness = 2;
        lblPlaceholder.FontAttributes = FontAttributes.None;
    }
}