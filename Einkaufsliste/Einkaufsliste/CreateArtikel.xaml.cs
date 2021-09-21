using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Einkaufsliste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateArtikel : ContentPage
    {
        public CreateArtikel()
        {
            InitializeComponent();
        }

        private void cmd_Speichern_Clicked(object sender, EventArgs e)
        {
            Product product = new Product();

            if (string.IsNullOrWhiteSpace(ent_CreateArtName.Text))
            {
                ent_CreateArtName.Text = "Keine Angabe";
            }
            if (string.IsNullOrWhiteSpace(edt_CreateArtBeschreibung.Text))
            {
                edt_CreateArtBeschreibung.Text = "Keine Angabe";
            }

            product.Name = ent_CreateArtName.Text;
            product.Beschreibung = edt_CreateArtBeschreibung.Text;

            Artikelliste.artikelliste.Add(product);

            ent_CreateArtName.Text = "";
            edt_CreateArtBeschreibung.Text = "";
        }

        private void cmd_Einkaufsliste_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void cmd_Artikelliste_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Artikelliste());
        }
    }
}