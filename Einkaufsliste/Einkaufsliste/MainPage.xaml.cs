using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Einkaufsliste
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        internal static ObservableCollection<Product> einkaufsliste = new ObservableCollection<Product>();

        public MainPage()
        {
            InitializeComponent();

            EinkaufslisteView.ItemsSource = einkaufsliste;
        }

        private void cmd_Create_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateArtikel());
        }

        private void cmd_Artikelliste_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Artikelliste());
        }

        private void EinkaufslisteView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var artikel = einkaufsliste.Where(x => x.Equals(e.SelectedItem)).FirstOrDefault();
            Artikelliste.artikelliste.Add(artikel);

            einkaufsliste.Remove(artikel);
        }
    }
}
