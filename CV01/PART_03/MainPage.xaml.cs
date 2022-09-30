namespace PART_03;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}


    void ShowPasswords(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e)
    {
		if (ShowPwSwitch.IsToggled)
		{
            pw1.IsPassword = false;
            pw2.IsPassword = false;
        }
		else
		{
            pw1.IsPassword = true;
            pw2.IsPassword = true;
        }
    }

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (pw1.Text == pw2.Text)
		{
            //await DisplayAlert("1", "2", "OK");
            await DisplayAlert("Password", "Your password is fine", "OK");
        }
        else
        {
            await DisplayAlert("Password", "Passwords doen't match", "OK");
        }
    }
}


