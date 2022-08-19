using Microsoft.Maui.Controls.Internals;

namespace Editor;

public partial class MainPage : ContentPage
{
	

	public MainPage(Vars v)
	{
		InitializeComponent();

		DataHandler.Create();
		DataHandler.LoadList();
		BindingContext = v;
	}

	private async void add_btn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Editor());
	}

	private async void settings_btn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Settings());
	}

	/*private async void LV_1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var segment = sender as ListView;
		var items = segment.ItemsSource as IList<List_Content>;

		if (items != null)
		{
			await Navigation.PushAsync(new Editor(Vars.list_1[e.SelectedItemIndex].title));
		}
	}*/

	private async void LV_1_ItemTapped(object sender, ItemTappedEventArgs e)
	{
        var segment = sender as ListView;
        var items = segment.ItemsSource as IList<List_Content>;

        if (items != null)
        {
            await Navigation.PushAsync(new Editor(Vars.list_1[e.ItemIndex].title));
        }
    }

	
}

