namespace MauiMeals;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
		InitializeComponent();
	}

    private async void ToMainpage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()); 
    }

}