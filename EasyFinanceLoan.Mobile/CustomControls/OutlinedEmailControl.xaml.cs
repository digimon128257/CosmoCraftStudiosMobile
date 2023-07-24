using CommunityToolkit.Maui.Behaviors;

namespace EasyFinanceLoan.Mobile.CustomControls;

public partial class OutliinedEmailControl : Grid
{
    public OutliinedEmailControl()
    {
        InitializeComponent();
        lblPlaceholder.FontSize = 12;
        lblPlaceholder.TranslateTo(0, -28, 80, easing: Easing.Linear);

        var validStyle = new Style(typeof(Entry));
        validStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Black
        });

        var invalidStyle = new Style(typeof(Entry));
        invalidStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Red
        });

        var emailValidationBehavior = new EmailValidationBehavior
        {
            InvalidStyle = invalidStyle,
            ValidStyle = validStyle,
            Flags = ValidationFlags.ValidateOnValueChanged,
        };

        txtEntry.Behaviors.Add(emailValidationBehavior);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(OutliinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
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

    private void txtEntry_Focused(object sender, FocusEventArgs e)
    {
        bdrOuter.Stroke = Color.FromArgb("ff00ff00");
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