using TasksApp.ViewModel;

namespace TasksApp;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}