namespace CV01_PART2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}


	private async void ShowSelected(Object sender, EventArgs e)
	{
		String message = "You have selected options:\n";
		if (sw1.IsToggled) message += "One\n";
        if (sw2.IsToggled) message += "Two\n";
        if (sw3.IsToggled) message += "Three\n";
		await DisplayAlert("Note", message, "OK");
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}


