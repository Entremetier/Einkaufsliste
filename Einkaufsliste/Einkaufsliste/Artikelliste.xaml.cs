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
            new Product(){Name = "Apfel", Beschreibung= "Ist ein leckeres Obst", WebLink="apfel.png"},
            new Product(){Name = "Maus", Beschreibung= "Kleines Nagetier", WebLink="maus"},
            new Product(){Name = "Trabant", Beschreibung= "Klassiker der Automobilindustrie", WebLink = "trabi"},
            new Product(){Name = "Mozartkugeln", Beschreibung= "Nur echt und lecker wenn sie von Fürst sind", WebLink="mozart"},
            new Product(){Name = "Birne", Beschreibung= "So ähnlich wie ein Apfel", WebLink="birne"},
            new Product(){Name = "Evolischuhe", Beschreibung= "Zuckersüß zum anziehen", WebLink="schuhe"}
        };

        public Artikelliste()
        {
            InitializeComponent();

            var sortedList = artikelliste.OrderBy(p => p.Name);

            ArtikellisteView.ItemsSource = sortedList;
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

            if (MainPage.einkaufsliste.Contains(artikel)) artikel.Zahl += 1;
            else
            {
                artikel.Zahl = 1;
                MainPage.einkaufsliste.Add(artikel);
            }
            //DisplayAlert(artikel.Name, $"wurde der Einkaufsliste hinzugefügt!", "Ok");
        }
    }
}