using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Einkaufsliste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Artikelliste : ContentPage
    {
        internal static ObservableCollection<Product> artikelliste = new ObservableCollection<Product>
        {
            new Product(){Name = "Apfel", Beschreibung= "Ist ein leckeres Obst"},
            new Product(){Name = "Maus", Beschreibung= "Kleines Nagetier"},
            new Product(){Name = "Trabant", Beschreibung= "Klassiker der Automobilindustrie"},
            new Product(){Name = "Mozartkugeln", Beschreibung= "Nur echt und lecker wenn sie von Fürst sind"}
        };

        public Artikelliste()
        {
            InitializeComponent();

            ArtikellisteView.ItemsSource = artikelliste;
        }

        private void cmd_Create_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateArtikel());
        }

        private void cmd_Einkaufsliste_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ArtikellisteView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var artikel = artikelliste.Where(x => x.Equals(e.SelectedItem)).FirstOrDefault(); 

            MainPage.einkaufsliste.Add(artikel);

            artikelliste.Remove(artikel);
        }
    }
}