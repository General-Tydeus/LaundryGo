using Microsoft.Maui.Controls;

namespace LaundryGo.Platforms.Android.Interface;

public partial class Outline : Grid
{
    public static Outline Instance;

    public Outline()
	{
		InitializeComponent();
        Instance = this;
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text),
		returnType: typeof(string),
		declaringType: typeof(Outline),
		defaultValue: null,
		defaultBindingMode: BindingMode.TwoWay);

	public string Text 
	{  
		get => ( string )GetValue( TextProperty );
		set => SetValue( TextProperty, value );
	}

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        propertyName: nameof(IsPassword),
        returnType: typeof(bool),
        declaringType: typeof(Outline),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWayToSource);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
		propertyName: nameof(PlaceHolder),
		returnType: typeof(string),
		declaringType: typeof(Outline),
		defaultValue: null,
		defaultBindingMode: BindingMode.OneWay);

	public string PlaceHolder 
	{  
		get => ( string )GetValue(PlaceHolderProperty);
		set => SetValue(PlaceHolderProperty, value );
	}

    private void txtEntry_Focused(object sender, FocusEventArgs e)
    {
		lblPlaceholder.FontSize = 12;
		lblPlaceholder.TranslateTo(0, -26, 80, easing: Easing.Linear);
    }

    private  void txtEntry_Unfocused(object sender, FocusEventArgs e)
    {

        if (!string.IsNullOrWhiteSpace(Text))
		{
            lblPlaceholder.FontSize = 12;
            lblPlaceholder.TranslateTo(0, -26, 80, easing: Easing.Linear);
            App.Current.MainPage.DisplayAlert("Error", $"{checkEntry()}", "OK");
            checkEntry();
        }
		else
		{
            lblPlaceholder.FontSize = 15;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }

    public string GetEntryValue()
    {
        return txtEntry.Text;
    }

    public string checkEntry()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            //return txtEntry.ToString();
        }
        return "No text";

    }
}