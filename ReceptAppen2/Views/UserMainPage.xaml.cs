namespace ReceptAppen2.Views;

public partial class UserMainPage : ContentPage
{
	public UserMainPage()
	{
		InitializeComponent();
		BindingContext = new UserMainPageViewModel();
	}
}