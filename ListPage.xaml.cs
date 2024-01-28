using System.Collections.ObjectModel;

namespace BevListaSQL;

public partial class ListPage : ContentPage
{
	BevListaDatabase database;
	ObservableCollection<Termek> termekek = new ObservableCollection<Termek>();
	public ListPage()
	{
		InitializeComponent();
		database = new BevListaDatabase();
	}

	private void Load()
	{
		termekek = new ObservableCollection<Termek>(database.GetItemsAsync().Result);
		termekekLSV.ItemsSource = termekek;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Load();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		int primaryKey = int.Parse((sender as ImageButton).ClassId);
		Termek keresett = termekek.Where(x => x.ID == primaryKey).FirstOrDefault();
		if (keresett != null)
		{
			termekek.Remove(keresett);
			await database.DeleteItemAsync(keresett);
			Load();
		}
    }
}