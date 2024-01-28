using System.Collections.ObjectModel;

namespace BevListaSQL
{
    public partial class MainPage : ContentPage
    {
        BevListaDatabase database;

        ObservableCollection<string> kategoriak = new ObservableCollection<string>() {"Hentesáru", "Tejtermék", "Pékáru", "Ital", "Snack", "Gyümölcs", "Zöldség"};

        public MainPage()
        {
            InitializeComponent();
            kategoriaPCK.ItemsSource = kategoriak;
            database = new BevListaDatabase();
        }

        private void minus_plusBTN_Clicked(object sender, EventArgs e)
        {
            int db = int.Parse(dbEnt.Text);
            Button btn = (Button)sender;
            if (btn.Text == "+")
                db++;
            else
                if (db > 1) db--;
            dbEnt.Text = db.ToString();
        }

        private async void addBTN_Clicked(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(termekNevEnt.Text))
            {
                Termek ujTermek = new Termek(termekNevEnt.Text, int.Parse(dbEnt.Text), kategoriaPCK.SelectedItem == null ? "" : kategoriaPCK.SelectedItem.ToString());
                termekNevEnt.IsEnabled = false;
                termekNevEnt.IsEnabled = true;
                termekNevEnt.Text = "";
                dbEnt.Text = "1";
                kategoriaPCK.SelectedItem = null;
                await database.SaveItemAsync(ujTermek);
            }
            else
            {
                await DisplayAlert("Hiba", "A termék nevét kötelező megadni!", "OK");
            }
        }
    }
}